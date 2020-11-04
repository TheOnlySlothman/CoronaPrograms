from collections import deque


def start(maze):
    visited = []
    queue = deque([maze.start])

    while queue:

        current = queue.popleft()

        visited.append(current)

        if current == maze.end:
            return visited

        queue.extend([x for x in current.Neighbours if x is not None and x not in visited and x not in queue])
