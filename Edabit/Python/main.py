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
    for x in range(0, len(lst)):
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
    test = re.split("[aeiouAEIOU]", txt)
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
    return [x[0] for x in sorted(friends)]
