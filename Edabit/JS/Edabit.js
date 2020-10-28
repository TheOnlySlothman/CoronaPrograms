console.debug(isSymmetrical(23));

/* eslint-disable no-unused-vars */
const products = [
    { number: 1, price: 100, name: 'Orange juice' },
    { number: 2, price: 200, name: 'Soda' },
    { number: 3, price: 150, name: 'Chocolate snack' },
    { number: 4, price: 250, name: 'Cookies' },
    { number: 5, price: 180, name: 'Gummy bears' },
    { number: 6, price: 500, name: 'Condoms' },
    { number: 7, price: 120, name: 'Crackers' },
    { number: 8, price: 220, name: 'Potato chips' },
    { number: 9, price: 80, name: 'Small snack' },
];
const coinArray = [500, 200, 100, 50, 20, 10];


function removeEmptyArrays(arr) {
    return arr.filter(x => x !== []);
}

function countdown(start) {
    const arr = new Array(start + 1);
    for(let i = 0; i < arr.length; i++) {
        arr[i] = start - i;
    }
    return arr;
}

function minimumRemovals(arr) {
    let sum;
    return arr.reduce(reduce) % 2 == 0 ? 0 : 1;
}
function reduce(num1, num2) {
    return num1 + num2;
}

function myPi(n) {
    const x = Number.parseFloat(Math.PI);
    const y = x.toFixed(n);
}

// /https://edabit.com/challenge/PYXbvQh9W3c9i72xx
// eslint-disable-next-line no-shadow
function vendingMachine(products, money, productNumber) {
    const product = products.find(x => x.number == productNumber);
    const changeAmount = money - product.price;
    let arr = [];

    for(let i = 0; i < coinArray.length; i++) {
        arr = arr.concat(getChange(changeAmount, coinArray[i]));
    }

    return { product: product.name, change: arr };
}


function getChange(money, change) {
    const arr = [];
    if(change < money) {
        arr.push(change);
        money = money - change;
        getChange(money, change);
        return arr;
    }
}
/** @param {string[]} arr */
function sortByLength(arr) {
    return arr.sort((a, b) => a.length - b.length);
}
/** @param {number[]} arr */
function sortNumsAscending(arr) {
    if (!arr) {
        return [];
    }
    return arr.sort((a, b) => a - b);
}
/** @param {{tile: string, score: number}[]} tileHand */
function maximumScore(tileHand) {
    return tileHand.map(x => x = x.score).reduce((a, b) => a + b);
}

/** @param {string[]} friends */
function societyName(friends) {
    return friends.sort().map(x => x = x[0]).join('');
}

/** @param {number[]} nums */
function getOnlyEvens(nums) {
    return nums.filter((val, i) => val % 2 == 0 && i % 2 == 0);
}

/** @param {number[]} arr */
function secondLargest(arr) {
    return arr.sort((a, b) => a - b)[arr.length - 2];
}

/** @param {string} path */
function isJS(path) {
    const regex = /(\.jsx?$)/g;
    return regex.test(path);
}

/** @param {string} str */
function bomb(str) {
    return str.toLowerCase().includes('bomb') ? 'Duck!!!' : 'There is no bomb, relax.';
}

/** @param {string} str */
function hashPlusCount(str) {
    const arr = [];
    arr.push(str.split('').filter(x => x == '#').length);
    arr.push(str.split('').filter(x => x == '+').length);
    return arr;
}
/** @param {string} str */
function firstVowel(str) {
    return str.toLowerCase().search(/([aeiou])/);
}

/** @param {number} num */
function largestSwap(num) {
    const str = num.toString().split('');
    return str[0] >= str[1];
}

/** @param {number} number */
function highestDigit(number) {
    return Math.max(...number.toString());
}
/** @param {number[]} arr */
function mean(arr) {
    return +(arr.reduce((a, b) => a + b) / arr.length).toFixed(2);
}

/** @param {number} num */
function isSymmetrical(num) {
    const arr = num.toString().split('');
    return arr.join('') == arr.reverse().join('');
}

/** @param {number} num */
function sortDescending(num) {
    return +num.toString().split('').sort((a, b) => b - a).join('');
}

/** @param {number[][]} arr @param {number} val*/
function isOmnipresent(arr, val) {
    return arr.every(x => x.includes(val));
}

/** @param {string} num */
function leftDigit(num) {
    return +num.match(/(\d)/)[0];
}

/** @param {number} num */
function factorial(num) {
    if (num == 1) {
        return num;
    }
    return num * factorial(num - 1);
}

/** @param {number} num */
function getDecimalPlaces(num) {
    if (!num.includes('.')) {
        return 0;
    }
    return num.toString().substring(num.toString().indexOf('.') + 1).length;
}

/** @param {string} str */
function highLow(str) {
    const arr = str.split(' ');
    return Math.max(...arr) + ' ' + Math.min(...arr);
}

/** @param {number[]} nums */
function maxTotal(nums) {
    return nums.sort((a, b) => a - b).slice(5).reduce((a, b) => a + b);
}

/** @param {string} nums */
function addNums(nums) {
    return Number(nums.split(', ').reduce((a, b) => Number(a) + Number(b)));
}

function toArray(num) {
    return num.toString().split('').map(x => x = +x);
}

function toNumber(arr) {
    return Number(arr.join(''));
}

/** @param {string} str */
function reverseCase(str) {
    const regex = /([A-Z])/;
    return str.split('').map(x => regex.test(x) ? x = x.toLowerCase() : x = x.toUpperCase()).join('');
}