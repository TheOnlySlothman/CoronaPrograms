from collections import deque


def start(maze):
    visited = []
    stack = deque([maze.start])
    prev = [[None for x in range(maze.width)] for y in range(maze.width)]

    while stack:

        current = stack.pop()

        visited.append(current)

        if current == maze.end:
            break

        neighbours = reversed([x for x in current.Neighbours if x is not None and x not in visited and x not in stack])
        for x in neighbours:
            prev[x.Position[1]][x.Position[0]] = current.Position
        stack.extend(neighbours)

    return visited
