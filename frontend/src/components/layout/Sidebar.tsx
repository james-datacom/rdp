import { NAV_ITEMS, type SectionId } from '../../sections'

type SidebarProps = {
  activeSection: SectionId
  onSelect: (section: SectionId) => void
}

export function Sidebar({ activeSection, onSelect }: SidebarProps) {
  return (
    <nav className="sidebar" aria-label="Primary">
      {NAV_ITEMS.map((item) => {
        const isActive = activeSection === item.id
        return (
          <button
            key={item.id}
            type="button"
            className={`nav-item${isActive ? ' active' : ''}`}
            aria-current={isActive ? 'page' : undefined}
            onClick={() => onSelect(item.id)}
          >
            {item.label}
          </button>
        )
      })}
    </nav>
  )
}
