from PIL import Image
from mazes import Maze
from pathlib import Path


def solve(input_file):
    im = Image.open(input_file)
    maze = Maze(im)


solve(Path('tiny.png'))
