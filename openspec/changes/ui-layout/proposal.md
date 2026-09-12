## Why

The RDP frontend currently renders a single centered todo list with no way to navigate between sections, so the app feels like a one-off demo rather than a multi-feature playground. Introducing a persistent application shell now gives future features a consistent place to plug in while keeping existing todo functionality intact.

## What Changes

- Add a full-viewport application shell with three regions: header, sidebar, and main content.
- Move the existing todo list into the main content area as the **Todos** section, preserving create, read, update, and delete behavior against `/api/todos`.
- Add sidebar navigation with at least **Todos**, **Dashboard**, and **Settings** menu items.
- Render placeholder content for Dashboard and Settings (heading plus descriptive text).
- Highlight the active sidebar item; default to **Todos** on first load.
- Switch main content on menu click without a full page reload (client-side state; no routing library required).
- Restyle the layout for desktop viewports (>= 1024px): full width shell, subtle header/sidebar separation, existing blue/slate palette.
- Extract focused layout components (e.g. `AppLayout`, `Header`, `Sidebar`, section views) from the monolithic `App.tsx`.

## Capabilities

### New Capabilities

- `frontend/app-layout`: Persistent application chrome (header and sidebar), section navigation, active-menu indication, and main-content swapping for Todos, Dashboard, and Settings views.

### Modified Capabilities

<!-- No existing specs under openspec/specs/. Todo API behavior is unchanged; only UI placement changes. -->

## Impact

- **Frontend (`frontend/src/`)**: Refactor `App.tsx` into a shell plus section views; add layout components and update `App.css` (or equivalent) for full-viewport desktop layout.
- **API / backend**: No changes. Existing Vite dev proxy and `/api/todos` integration must continue to work.
- **Dependencies**: No new packages expected unless a router is already present (story prefers `useState`-based section switching).
- **Out of scope**: Authentication, mobile/collapsible sidebar, real dashboard metrics, functional settings, backend changes.
