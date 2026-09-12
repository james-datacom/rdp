## Context

See `proposal.md` for motivation. Today `frontend/src/App.tsx` is a single component that renders a centered header and todo list (`max-width: 640px`). There is no sidebar, no section switching, and no routing library in `package.json` (React 19 + Vite only). Todo CRUD logic and styles live inline in `App.tsx` / `App.css`. Requirements are defined in `specs/frontend/app-layout/spec.md`.

## Goals / Non-Goals

**Goals:**

- Introduce a reusable application shell (header, sidebar, main) that fills the desktop viewport.
- Extract todo UI into a dedicated section view without changing `/api/todos` integration.
- Switch sections via client-side state with Todos as the default.
- Preserve existing color palette (`#2563eb` accent, slate grays) and lint/build compatibility.

**Non-Goals:**

- Adding `react-router` or other navigation dependencies.
- Mobile/collapsible sidebar, authentication, real dashboard metrics, or backend changes.
- CSS-in-JS or a component library; stay with plain CSS consistent with `App.css`.

## Decisions

### 1. Component decomposition

Split the monolithic `App.tsx` into small, focused modules:

```
frontend/src/
  App.tsx                  # active section state + layout wiring
  App.css                  # shell + shared styles; todo styles retained
  components/layout/
    AppLayout.tsx          # grid shell: header + body (sidebar + main)
    Header.tsx             # RDP title + subtitle
    Sidebar.tsx            # nav items, active state, click handlers
  views/
    TodosView.tsx          # existing todo logic (lifted from App.tsx)
    DashboardView.tsx      # static placeholder
    SettingsView.tsx       # static placeholder
```

**Rationale:** Matches the story's suggested structure and keeps layout chrome separate from feature views. Future sections add a view file and a sidebar entry.

**Alternative considered:** Keep everything in `App.tsx` with inline conditionals. Rejected because it recreates the monolith and makes later sections harder to add.

### 2. Section switching via `useState` (no router)

Define a section id union:

```typescript
type SectionId = 'todos' | 'dashboard' | 'settings'
```

`App.tsx` holds `activeSection` (default `'todos'`). `Sidebar` receives `activeSection` and `onSelect(section)`. The main area renders the matching view with a simple lookup map or `switch`.

**Rationale:** No router in dependencies; story explicitly allows `useState`. Sufficient for three static sections.

**Alternative considered:** Add `react-router-dom`. Rejected as unnecessary scope for placeholder sections with no URL requirements.

### 3. Todo state when navigating away

Use **conditional rendering** (`activeSection === 'todos' && <TodosView />`). `TodosView` already loads todos in `useEffect` on mount, so returning to Todos re-fetches from the API.

**Rationale:** Simplest approach; satisfies the spec's "preserved in state or re-fetched" allowance. Avoids keeping hidden mounted views.

**Alternative considered:** Keep all views mounted and toggle visibility with CSS. Preserves in-progress form input when switching sections, but adds DOM complexity for minimal benefit in this story.

### 4. Layout CSS with CSS Grid

Structure:

```
.app-shell          min-height: 100vh; display: grid;
                    grid-template-rows: auto 1fr;
.app-body           display: grid;
                    grid-template-columns: 220px 1fr;
.sidebar            fixed width, border-right, subtle background
.main-content       padding, flex-grow, optional max-width for readability inside forms/lists
.header             full-width top bar, border-bottom
```

Remove the current `.app { max-width: 640px }` constraint from the shell. Apply readable width only inside section content if needed (e.g. todo form/list container).

**Rationale:** Grid cleanly models header-over-body and sidebar-beside-main without extra wrapper hacks. Works at >= 1024px per spec.

**Alternative considered:** Flexbox-only layout. Viable but grid makes the two-dimensional shell more explicit.

### 5. Sidebar accessibility and active state

- Render nav items as `<button type="button">` (not `<a href="#">`) since there are no routes.
- Apply an `.active` class (background tint + `#2563eb` left border or bold text) on the selected item.
- Set `aria-current="page"` on the active button.
- Provide `:hover` and `:focus-visible` styles for pointer and keyboard users.

**Rationale:** Buttons are semantically correct for in-app view switching; `aria-current` communicates selection to assistive tech.

### 6. Placeholder views

`DashboardView` and `SettingsView` are static functional components: an `<h2>` heading and a short `<p>` describing the section. No shared placeholder abstraction needed yet.

### 7. Styling approach

Extend `App.css` rather than introducing per-component CSS files. Add layout classes (`.app-shell`, `.sidebar`, `.nav-item`, etc.) alongside existing todo classes. Move todo-specific rules under a `.todos-view` wrapper if needed to avoid layout bleed.

**Rationale:** Matches current project pattern (single CSS import from `App.tsx`).

## Risks / Trade-offs

- **[Unsaved todo form input lost on navigation]** → Acceptable per spec; user can re-enter. Re-fetch on return ensures list data is current.
- **[No deep-linkable URLs]** → Out of scope; a future router story can map sections to paths.
- **[Desktop-only layout]** → Shell uses full width without responsive collapse; narrow viewports may scroll horizontally. Mobile menu deferred to a follow-up story.
- **[CSS specificity growth in App.css]** → Mitigate by grouping layout vs. todo rules with clear section comments; split files only if size becomes unwieldy.

## Migration Plan

1. Add layout and view components without changing todo behavior.
2. Rewire `App.tsx` to render `AppLayout` with section switching.
3. Update `App.css` for full-viewport shell; verify todo styles still apply inside `TodosView`.
4. Manual smoke test: `npm run dev`, navigate all three sections, exercise todo CRUD, run `npm run lint` and `npm run build`.
5. Rollback: revert frontend changes only; no backend or config changes required.
