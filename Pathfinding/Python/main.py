from PIL import Image
from mazes import Maze
from pathlib import Path
import depthfirst
import breadthfirst


def draw_nodes(position_list, img):
    img = img.convert('RGB')
    img_pixels = img.load()

    # for x in position_list:
    # img_pixels[x[0], x[1]] = (0, 200, 0)

    for x in range(len(position_list)):
        r = int((x / len(position_list)) * 255)
        img_pixels[position_list[x][0], position_list[x][1]] = (r, 0, 255 - r)

    img.save('node_map.png')


def draw_visited_nodes(position_list, img, name):
    img = img.convert('RGB')
    img_pixels = img.load()

    for x in range(len(position_list)):
        # Blue - red
        r = int((x / len(position_list)) * 255)
        img_pixels[position_list[x][0], position_list[x][1]] = (r, 0, 255 - r)

    img.save(f'{name}.png')


def solve(input_file):
    img = Image.open(input_file)
    maze = Maze(img)

    for x in maze.node_char_list:
        print(x)

    draw_nodes([x.Position for x in maze.node_list], img)
    draw_visited_nodes([x.Position for x in depthfirst.start(maze)], img, 'depth_first')
    draw_visited_nodes([x.Position for x in breadthfirst.start(maze)], img, 'breadth_first')


# solve(Path('tiny.png'))
solve(Path('braid200.png'))
