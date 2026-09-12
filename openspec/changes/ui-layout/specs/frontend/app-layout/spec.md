## Purpose

Defines the persistent application shell and section navigation for the RDP frontend, enabling multiple playground features to share a common header, sidebar, and main content area.

## ADDED Requirements

### Requirement: Application shell regions

The frontend SHALL render a full-viewport layout with three regions: a header spanning the full width above a body that contains a fixed-width sidebar on the left and a main content area occupying the remaining horizontal space.

#### Scenario: Shell visible on desktop

- **WHEN** the user loads the application on a viewport at least 1024px wide
- **THEN** the UI displays header, sidebar, and main content regions without horizontal overflow

### Requirement: Persistent header branding

The header SHALL display **RDP** as the application name and a subtitle identifying the React Dotnet Playground. The header SHALL remain visible at the top of the viewport while the user navigates between sidebar sections.

#### Scenario: Header visible during navigation

- **WHEN** the user selects a different sidebar menu item
- **THEN** the header with app name and subtitle remains visible and unchanged in position

### Requirement: Sidebar navigation menu

The sidebar SHALL provide primary navigation with menu items labeled **Todos**, **Dashboard**, and **Settings**.

#### Scenario: Navigation items listed

- **WHEN** the application shell is displayed
- **THEN** the sidebar lists Todos, Dashboard, and Settings as selectable menu items

### Requirement: Active navigation indication

The sidebar SHALL visually distinguish the currently selected menu item from inactive items.

#### Scenario: Active item highlighted

- **WHEN** a sidebar menu item is selected
- **THEN** that item is visually distinct from the other menu items

### Requirement: Default section on initial load

The application SHALL select **Todos** as the active section when first loaded.

#### Scenario: Todos selected by default

- **WHEN** the user opens the application for the first time in a session
- **THEN** Todos is the active sidebar item and the main content area shows the Todos view

### Requirement: Client-side section switching

Selecting a sidebar menu item SHALL update the active navigation state and display the corresponding section content in the main area without a full page reload.

#### Scenario: Menu click swaps content

- **WHEN** the user clicks a sidebar menu item other than the currently active item
- **THEN** the active sidebar indication updates and the main content area shows the view for that menu item without reloading the page

### Requirement: Todos section CRUD behavior

The Todos section SHALL preserve create, read, update, and delete behavior for todos against the backend `/api/todos` endpoints.

#### Scenario: Create todo

- **WHEN** the user submits a new todo title in the Todos section
- **THEN** the application creates the todo via the backend API and displays it in the list

#### Scenario: Toggle todo completion

- **WHEN** the user toggles a todo's completion checkbox in the Todos section
- **THEN** the application persists the updated completion state via the backend API

#### Scenario: Edit todo title

- **WHEN** the user edits a todo title and commits the change in the Todos section
- **THEN** the application persists the updated title via the backend API

#### Scenario: Delete todo

- **WHEN** the user deletes a todo in the Todos section
- **THEN** the application removes the todo via the backend API and it no longer appears in the list

### Requirement: Dashboard placeholder content

The Dashboard section SHALL display a heading and brief descriptive placeholder text that identifies the section as the dashboard area.

#### Scenario: Dashboard placeholder shown

- **WHEN** the user selects Dashboard in the sidebar
- **THEN** the main content area shows a dashboard heading and placeholder descriptive text

### Requirement: Settings placeholder content

The Settings section SHALL display a heading and brief descriptive placeholder text that identifies the section as the settings area.

#### Scenario: Settings placeholder shown

- **WHEN** the user selects Settings in the sidebar
- **THEN** the main content area shows a settings heading and placeholder descriptive text

### Requirement: Todo data persistence across navigation

When the user navigates away from the Todos section and returns, previously loaded or entered todo data SHALL NOT be lost. The application MAY preserve component state or re-fetch from the backend on return.

#### Scenario: Return to Todos preserves data

- **WHEN** the user views Todos, navigates to another section, then returns to Todos
- **THEN** todo data is still available (retained in state or re-fetched from the API)

### Requirement: Sidebar interaction affordances

Sidebar navigation items SHALL provide visible hover and focus states for both pointer and keyboard users.

#### Scenario: Keyboard focus visible

- **WHEN** a sidebar menu item receives keyboard focus
- **THEN** the item displays a visible focus indication
