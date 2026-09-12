export interface Todo {
  id: string
  title: string
  isCompleted: boolean
  createdAt: string
}

export interface CreateTodoRequest {
  title: string
}

export interface UpdateTodoRequest {
  title: string
  isCompleted: boolean
}

async function handleResponse<T>(response: Response): Promise<T> {
  if (!response.ok) {
    const message = await response.text()
    throw new Error(message || `Request failed with status ${response.status}`)
  }

  if (response.status === 204) {
    return undefined as T
  }

  return response.json() as Promise<T>
}

export async function getTodos(): Promise<Todo[]> {
  const response = await fetch('/api/todos')
  return handleResponse<Todo[]>(response)
}

export async function createTodo(request: CreateTodoRequest): Promise<Todo> {
  const response = await fetch('/api/todos', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(request),
  })
  return handleResponse<Todo>(response)
}

export async function updateTodo(
  id: string,
  request: UpdateTodoRequest,
): Promise<Todo> {
  const response = await fetch(`/api/todos/${id}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(request),
  })
  return handleResponse<Todo>(response)
}

export async function deleteTodo(id: string): Promise<void> {
  const response = await fetch(`/api/todos/${id}`, { method: 'DELETE' })
  await handleResponse<void>(response)
}
