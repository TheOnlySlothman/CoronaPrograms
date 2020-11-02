class Maze:
    class Node:
        def __init__(self, position):
            self.Position = position
            self.Neighbours = [None, None, None, None]

    def __init__(self, im):
        width = im.size[0]
        height = im.size[1]
        data = list(im.getdata(0))

        self.start = None
        self.end = None

        for x in range(1, width - 1):
            if data[x] > 0:
                self.start = Maze.Node(f'{x},0')

        top_node = [None] * width
        for y in range(1, height - 1):
            row_beginning = width * y
            row_above = row_beginning - width
            row_below = row_beginning + width

            prev = False
            current = False
            next = data[row_beginning + 1] != 0

            left_node = None
            for x in range(1, width - 1):
                arr = [arr[1], arr[2], data[row_beginning + 1 + x] != 0]

                n = None

                if arr[1] == 0:
                    continue

                # if data[row_above + x] != 0 or data[row_below + x]:
                # n = Maze.Node(f'{x},{y}')
                # if data[row_above + x] != 0:
                # top_node[x].Neighbours[1] = n
                # n.Neighbours[0] = top_node[x]
