import type { ReactNode } from 'react'
import type { SectionId } from '../../sections'
import { Header } from './Header'
import { Sidebar } from './Sidebar'

type AppLayoutProps = {
  activeSection: SectionId
  onSelectSection: (section: SectionId) => void
  children: ReactNode
}

export function AppLayout({
  activeSection,
  onSelectSection,
  children,
}: AppLayoutProps) {
  return (
    <div className="app-shell">
      <Header />
      <div className="app-body">
        <Sidebar activeSection={activeSection} onSelect={onSelectSection} />
        <main className="main-content">{children}</main>
      </div>
    </div>
  )
}
