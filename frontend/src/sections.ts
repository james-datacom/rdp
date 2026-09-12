export type SectionId = 'todos' | 'dashboard' | 'settings'

export const NAV_ITEMS: { id: SectionId; label: string }[] = [
  { id: 'todos', label: 'Todos' },
  { id: 'dashboard', label: 'Dashboard' },
  { id: 'settings', label: 'Settings' },
]
