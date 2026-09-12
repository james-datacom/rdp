## 1. Layout components

- [x] 1.1 Create `frontend/src/components/layout/Header.tsx` displaying **RDP** and subtitle "React Dotnet Playground" and verify it renders both text elements
- [x] 1.2 Create `frontend/src/components/layout/Sidebar.tsx` with Todos, Dashboard, and Settings buttons, active `.active` class, and `aria-current="page"` on the selected item; verify all three labels render and clicking calls `onSelect` with the correct section id
- [x] 1.3 Create `frontend/src/components/layout/AppLayout.tsx` composing Header, Sidebar, and a main content slot in a header-over-body grid shell; verify the three regions appear when rendered with a test child in main

## 2. Section views

- [x] 2.1 Extract existing todo logic from `App.tsx` into `frontend/src/views/TodosView.tsx` preserving CRUD against `/api/todos`; verify create, toggle, edit, and delete still work in isolation
- [x] 2.2 Create `frontend/src/views/DashboardView.tsx` with a dashboard heading and placeholder descriptive text; verify the heading and paragraph render when the component mounts
- [x] 2.3 Create `frontend/src/views/SettingsView.tsx` with a settings heading and placeholder descriptive text; verify the heading and paragraph render when the component mounts

## 3. App wiring

- [x] 3.1 Add `SectionId` type and `activeSection` state (default `'todos'`) in `App.tsx`; verify Todos is selected on initial load
- [x] 3.2 Wire `App.tsx` to render `AppLayout` with conditional section views (Todos, Dashboard, Settings) and pass `activeSection` / `onSelect` to `Sidebar`; verify clicking each sidebar item swaps main content without a page reload
- [x] 3.3 Verify navigating away from Todos and back re-fetches or retains todo list data (no empty list after return unless the API has no todos)

## 4. Styles

- [x] 4.1 Update `App.css` with full-viewport grid shell classes (`.app-shell`, `.app-body`, `.header`, `.sidebar`, `.main-content`, `.nav-item`) using existing palette (`#2563eb`, slate grays); verify layout fills the viewport at >= 1024px without horizontal overflow
- [x] 4.2 Add sidebar hover and `:focus-visible` styles and active-item distinction; verify focus ring or highlight appears when tabbing through nav buttons
- [x] 4.3 Scope or retain todo-specific styles under `.todos-view` so form and list styling is unchanged inside the main content area; verify todo form and list appearance matches pre-refactor behavior

## 5. Verification

- [x] 5.1 Run `npm run lint` in `frontend/` and verify it exits with code 0
- [x] 5.2 Run `npm run build` in `frontend/` and verify it completes without errors
- [x] 5.3 Manual smoke test via `npm run dev`: confirm header stays visible while switching sections, all three views render, and todo CRUD works against the backend API
