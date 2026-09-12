**Story**

Enhance the RDP frontend with a consistent application shell so the app feels like a multi-section playground rather than a single-page todo list. The existing todo functionality should remain available, but it should live inside a navigable layout with a header, sidebar, and main content area.

**Context**

The frontend currently renders a centered todo list with a simple header. There is no sidebar or way to switch between sections. This change introduces a reusable layout that future features can plug into.

**Goals**

- Provide a clear, persistent app chrome (header + sidebar) across all views.
- Move the existing Todos feature into the main content area as one navigable section.
- Add at least one additional sample section to demonstrate menu-driven content switching.
- Keep the implementation simple: no routing library required unless already in the project.

---

**Layout Structure**

The page should use a full-viewport shell with three regions:

| Region   | Purpose |
|----------|---------|
| Header   | App branding and global context |
| Sidebar  | Primary navigation between sections |
| Main     | Content for the currently selected menu item |

Suggested structure:

```
┌─────────────────────────────────────────────┐
│ Header (app title, optional subtitle)       │
├──────────┬──────────────────────────────────┤
│ Sidebar  │ Main content area                │
│ (nav)    │ (changes based on selected menu) │
│          │                                  │
└──────────┴──────────────────────────────────┘
```

---

**Header Requirements**

- Display the app name: **RDP** (React Dotnet Playground).
- Include a short subtitle or tagline (e.g. "React Dotnet Playground").
- Remain visible at the top while navigating between sidebar items.
- Span the full width above the sidebar and main content.

---

**Sidebar Requirements**

- Fixed-width vertical navigation on the left.
- Include a **sample menu** with at least these items:

  | Menu label | Main content |
  |------------|--------------|
  | Todos      | Existing todo list (create, toggle, edit, delete) |
  | Dashboard  | Placeholder welcome/summary view (static content is fine) |
  | Settings   | Placeholder settings view (static content is fine) |

- Clearly indicate the **active** menu item (e.g. highlight, accent color, or bold text).
- Clicking a menu item updates the main content area without a full page reload.

---

**Main Content Requirements**

- Occupies the remaining horizontal space beside the sidebar.
- Renders only the content for the selected menu item.
- **Todos:** preserve current behavior and API integration (`/api/todos`).
- **Dashboard / Settings:** show a heading and brief placeholder text describing the section.
- When switching menus, previously entered todo data should not be lost (component state may be preserved or re-fetched on return—either is acceptable for this story).

---

**Interaction & Behavior**

- On first load, **Todos** is the default selected menu item.
- Clicking a sidebar item:
  1. Updates the active state in the sidebar.
  2. Swaps the main content to the matching view.
- No backend changes are required for this story.

---

**Visual & UX Guidelines**

- Use the existing color palette where possible (blue accent `#2563eb`, slate grays).
- Layout should use the full browser width on desktop (move away from the current narrow centered column for the shell).
- Sidebar and header should have subtle separation (border or background contrast).
- Main content should have comfortable padding and readable line length for forms and lists.
- Hover and focus states on sidebar links should be visible for keyboard and mouse users.

---

**Technical Notes**

- Stack: React 19, Vite, TypeScript (existing `frontend/` app).
- Prefer small, focused components (e.g. `AppLayout`, `Sidebar`, `Header`, section views).
- Client-side state (e.g. `useState` for active menu) is sufficient; a router is optional.
- Styles may extend `App.css` or use component-scoped classes consistent with current patterns.
- Do not break the Vite dev proxy or existing todo API calls.

---

**Out of Scope**

- Authentication or user profile in the header.
- Collapsible/mobile hamburger menu (may be a follow-up story).
- Real dashboard metrics or functional settings.
- Backend API changes.

---

**Acceptance Criteria**

- [ ] The UI displays a **header**, **sidebar**, and **main content** region in a full-viewport layout.
- [ ] The header shows the app name and subtitle and stays visible while navigating.
- [ ] The sidebar lists at least **Todos**, **Dashboard**, and **Settings** as sample menu items.
- [ ] The active menu item is visually distinct from inactive items.
- [ ] **Todos** is selected by default on initial load.
- [ ] Clicking a sidebar menu item updates the main content to the corresponding view without a full page reload.
- [ ] The **Todos** view retains existing create, read, update, and delete behavior against the backend API.
- [ ] **Dashboard** and **Settings** show identifiable placeholder content (heading + descriptive text).
- [ ] Layout is usable on a typical desktop viewport (≥ 1024px wide) without horizontal overflow.
- [ ] No regressions to `npm run dev` or existing frontend lint/build scripts.
