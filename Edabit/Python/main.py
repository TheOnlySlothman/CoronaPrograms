import math
import re


def add_suffix(suffix):
    return lambda x: x + suffix


def profit(info):
    return round((info['sell_price'] - info['cost_price']) * info['inventory'])


def alphanumeric_restriction(s):
    return s.isalpha() | s.isdigit()


def count_vowels(txt):
    return len(re.findall("[aeiou]", txt))


def filter_list(lst):
    return list(filter(lambda x: isinstance(x, int), lst))


def are_true(a, b):
    return ("both" if b else "first") if a else "second" if b else "neither"


# return a ? b ? "both" : "first" : b ? "second" : "neither"


def is_curzon(num):
    return (2 ** num + 1) % (2 * num + 1) == 0


def is_valid_PIN(pin):
    return True if re.search('^\d{4}$|^\d{6}$', pin) is not None else False


def cars_needed(n):
    return math.ceil(n / 5)


def add_indexes(lst):
    for x in range(len(lst)):
        lst[x] = lst[x] + x
    return lst


def is_symmetrical(num):
    return str(num) == str(num)[::-1]


def find_bob(names):
    if "Bob" not in names:
        return -1
    return names.index("Bob")


def calc_diff(obj, limit):
    sum = 0
    for x in obj:
        sum += obj[x]
    return sum - limit


def count_characters(lst):
    sum = 0
    for x in lst:
        sum += len(x)
    return sum


def simon_says(lst1, lst2):
    lst2.pop(0)
    for x in range(0, len(lst2)):
        if lst1[x] is not lst2[x]:
            return False
    return True


def paths(n):
    if n == 1:
        return n
    return n * paths(n - 1)


def remove_vowels(txt):
    return txt.translate(str.maketrans('', '', "aeiouAEIOU"))


def num_of_digits(num):
    return len(abs(num))


def integer_boolean(n):
    lst = []
    for x in n:
        lst.append(bool(int(x)))
    return lst


def move_to_end(lst, el):
    return [x for x in lst if x != el] + [x for x in lst if x == el]


def mood_today(mood="neutral"):
    return "Today, I am feeling " + mood


def oddeven(lst):
    return len(list(filter(lambda x: x % 2 == 1, lst))) > len(list(filter(lambda x: x % 2 == 0, lst)))


def num_args(*args):
    return len(args)


def replace_vowels(txt, ch):
    return ch.join(re.split('[aeiouAEIOU]', txt))


def correct_stream(user, correct):
    lst = []
    for x in range(len(user)):
        if user[x] == correct[x]:
            lst.append(1)
        else:
            lst.append(-1)
    return lst


def letter_counter(lst, letter):
    temp = 0
    for x in lst:
        temp += len(list(filter(lambda x: x == letter, x)))
    return temp


def profit_margin(cost_price, sales_price):
    return str(round((sales_price - cost_price) / sales_price * 100, 1)) + '%'


def mapping(letters):
    dic = {}
    for x in letters:
        dic[x] = x.upper()
    return dic


def probability(lst, n):
    return round(100 * (len(list(filter(lambda x: x >= n, lst))) / len(lst)), 1)


def society_name(friends):
    return ''.join([x[0] for x in sorted(friends)])


def century_from_year(year):
    return math.ceil(year / 100)


def unique(lst):
    for x in lst:
        if lst.count(x) == 1:
            return x


def magnitude(lst):
    sum = 0
    for x in lst:
        sum += math.pow(x, 2)
    return math.sqrt(sum)


def greet_people(names):
    for x in range(len(names)):
        names[x] = "Hello " + names[x]
    return ", ".join(names)


def sort_by_length(lst):
    return sorted(lst, key=lambda x: len(x))


def can_alternate(s):
    return abs(s.count('1') - s.count('0')) < 2


def index_multiplier(lst):
    sum = 0
    for x in range(len(lst)):
        sum += lst[x] * x
    return sum


def cars(wheels, bodies, figures):
    return min(math.floor(wheels / 4), bodies, math.floor(figures / 2))


def find_odd(lst):
    uniques = []
    for x in lst:
        if uniques.count(x) == 0:
            uniques.append(x)
    for x in uniques:
        if lst.count(x) % 2 == 1:
            return x


def first_and_last(s):
    return [''.join(sorted(s)), ''.join(reversed(sorted(s)))]


def remove_enemies(names, enemies):
    return [x for x in names if x not in enemies]


def ascii_capitalize(txt):
    lst = []
    for x in txt:
        if ord(x) % 2 == 0:
            lst.append(x.upper())
        else:
            lst.append(x.lower())
    return ''.join(lst)


def get_budgets(lst):
    sum = 0
    for x in lst:
        sum += x['budget']
    return sum


def larger_than_right(lst):
    numbers = []
    # numbers = [x for x in reversed(lst) if len(numbers) == 0 or x < max(numbers)]
    for x in reversed(lst):
        if len(numbers) == 0 or x > max(numbers):
            numbers.append(x)
    return list(reversed(numbers))


def return_only_integer(lst):
    return [x for x in lst if type(x) is int]


def is_subset(lst1, lst2):
    return set(lst1).issubset(set(lst2))


def reverse(txt):
    return ''.join([x.swapcase() for x in reversed(txt)])


def card_hide(card):
    lst = []
    for x in range(len(card) - 4):
        lst.append('*')
    return ''.join(lst + card[-4:].split())


def showdown(p1, p2):
    if p1.find("Bang!") < p2.find("Bang!"):
        return 'p1'
    elif p1.find("Bang!") > p2.find("Bang!"):
        return 'p2'
    else:
        return 'tie'


def how_many_times(msg):
    sum = 0
    for x in msg:
        sum += ord(x) - 96
    return sum


def nth_smallest(lst, n):
    if len(lst) < n:
        return
    return sorted(lst)[n - 1]


def convert_cartesian(x, y):
    return [list(i) for i in zip(x, y)]


def eda_bit(start, end):
    lst = []
    for x in range(start, end + 1):
        if x % 3 == 0:
            if x % 5 == 0:
                lst.append("EdaBit")
            else:
                lst.append("Eda")
        elif x % 5 == 0:
            lst.append("Bit")
        else:
            lst.append(x)
    return lst


def line_length(dot1, dot2):
    return round(math.sqrt(math.pow(abs(dot1[0] - dot2[0]), 2) + math.pow(abs(dot1[1] - dot2[1]), 2)), 2)


def adds_n(n):
    return lambda x: x + n


def neutralise(s1, s2):
    return ''.join([x if x == y else '0' for x, y in zip(s1, s2)])


def lines_are_parallel(l1, l2):
    return l1[0] / l1[1] == l2[0] / l2[1]


def which_is_larger(f, g):
    if f() > g():
        return 'f'
    elif f() < g():
        return 'g'
    return 'neither'


def pentagonal(num):
    if num <= 1:
        return 1
    return (num - 1) * 5 + pentagonal(num - 1)


print(neutralise("--++--", "++--++"))
