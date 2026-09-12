import { useState } from 'react'
import { AppLayout } from './components/layout/AppLayout'
import type { SectionId } from './sections'
import { DashboardView } from './views/DashboardView'
import { SettingsView } from './views/SettingsView'
import { TodosView } from './views/TodosView'
import './App.css'

function App() {
  const [activeSection, setActiveSection] = useState<SectionId>('todos')

  function renderSection() {
    switch (activeSection) {
      case 'dashboard':
        return <DashboardView />
      case 'settings':
        return <SettingsView />
      case 'todos':
      default:
        return <TodosView />
    }
  }

  return (
    <AppLayout
      activeSection={activeSection}
      onSelectSection={setActiveSection}
    >
      {renderSection()}
    </AppLayout>
  )
}

export default App
