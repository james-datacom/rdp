import { useCallback, useEffect, useState } from 'react'
import type { FormEvent } from 'react'
import {
  createTodo,
  deleteTodo,
  getTodos,
  updateTodo,
} from './api/todos'
import type { Todo } from './api/todos'
import './App.css'

function App() {
  const [todos, setTodos] = useState<Todo[]>([])
  const [title, setTitle] = useState('')
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)
  const [submitting, setSubmitting] = useState(false)

  const loadTodos = useCallback(async () => {
    setError(null)
    setLoading(true)
    try {
      const data = await getTodos()
      setTodos(data)
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to load todos')
    } finally {
      setLoading(false)
    }
  }, [])

  useEffect(() => {
    void loadTodos()
  }, [loadTodos])

  async function handleCreate(event: FormEvent) {
    event.preventDefault()
    const trimmed = title.trim()
    if (!trimmed) return

    setSubmitting(true)
    setError(null)
    try {
      const created = await createTodo({ title: trimmed })
      setTodos((current) => [created, ...current])
      setTitle('')
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to create todo')
    } finally {
      setSubmitting(false)
    }
  }

  async function handleToggle(todo: Todo) {
    setError(null)
    try {
      const updated = await updateTodo(todo.id, {
        title: todo.title,
        isCompleted: !todo.isCompleted,
      })
      setTodos((current) =>
        current.map((item) => (item.id === updated.id ? updated : item)),
      )
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to update todo')
    }
  }

  async function handleTitleChange(todo: Todo, newTitle: string) {
    setError(null)
    try {
      const updated = await updateTodo(todo.id, {
        title: newTitle,
        isCompleted: todo.isCompleted,
      })
      setTodos((current) =>
        current.map((item) => (item.id === updated.id ? updated : item)),
      )
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to update todo')
    }
  }

  async function handleDelete(id: string) {
    setError(null)
    try {
      await deleteTodo(id)
      setTodos((current) => current.filter((item) => item.id !== id))
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to delete todo')
    }
  }

  return (
    <div className="app">
      <header className="header">
        <h1>RDP</h1>
        <p>React Dotnet Playground — Todos</p>
      </header>

      <main className="main">
        <form className="todo-form" onSubmit={handleCreate}>
          <input
            type="text"
            value={title}
            onChange={(event) => setTitle(event.target.value)}
            placeholder="What needs to be done?"
            disabled={submitting}
          />
          <button type="submit" disabled={submitting || !title.trim()}>
            Add
          </button>
        </form>

        {error && <p className="error">{error}</p>}

        {loading ? (
          <p className="status">Loading todos...</p>
        ) : todos.length === 0 ? (
          <p className="status">No todos yet. Add one above.</p>
        ) : (
          <ul className="todo-list">
            {todos.map((todo) => (
              <li key={todo.id} className={todo.isCompleted ? 'completed' : ''}>
                <label className="todo-item">
                  <input
                    type="checkbox"
                    checked={todo.isCompleted}
                    onChange={() => void handleToggle(todo)}
                  />
                  <input
                    type="text"
                    className="todo-title"
                    value={todo.title}
                    onChange={(event) =>
                      setTodos((current) =>
                        current.map((item) =>
                          item.id === todo.id
                            ? { ...item, title: event.target.value }
                            : item,
                        ),
                      )
                    }
                    onBlur={(event) =>
                      void handleTitleChange(todo, event.target.value.trim())
                    }
                  />
                </label>
                <button
                  type="button"
                  className="delete"
                  onClick={() => void handleDelete(todo.id)}
                >
                  Delete
                </button>
              </li>
            ))}
          </ul>
        )}
      </main>
    </div>
  )
}

export default App
