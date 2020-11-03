from PIL import Image
from mazes import Maze
from pathlib import Path


def draw_nodes(position_list, img):
    img = img.convert('RGB')
    img_pixels = img.load()

    for x in position_list:
        img_pixels[x[0], x[1]] = (0, 0, 200)

    img.save('node_map.png')


def solve(input_file):
    img = Image.open(input_file)
    maze = Maze(img)

    for x in maze.node_char_list:
        print(x)

    draw_nodes([x.Position for x in maze.node_list], img)


solve(Path('tiny.png'))
# solve(Path('braid200.png'))
