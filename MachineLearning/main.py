import pandas as pd
from sklearn.tree import DecisionTreeClassifier, DecisionTreeRegressor
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score, mean_squared_error, r2_score
from sklearn import linear_model, datasets, svm
import numpy as np

import matplotlib.pyplot as plt

def plot(x_train, x_test, y_train, y_test, predictions):
    plt.scatter(x_test, y_test, color='black')
    plt.scatter(x_train, y_train, color='green')
    plt.plot(x_test, predictions, color='blue', linewidth=5)

    plt.xticks(())
    plt.yticks(())

    plt.show()


def linear_regression():
    df = pd.read_csv('test2.csv')

    x = df['year'].values.reshape(-1, 1)
    y = df['data_val'].values

    # for i in range(x.size):

    """
    df = pd.read_csv('test.csv')
    
    x = df.drop(columns=['z'])
    y = df['z']
    """
    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2)

    """
    model = DecisionTreeClassifier()
    model.fit(x_train, y_train)
    predictions = model.predict(x_test)
    """

    regr = linear_model.LinearRegression()

    regr.fit(x_train, y_train)
    predictions = regr.predict(x_test)

    print(regr.coef_)

    # score = accuracy_score(y_test, predictions)
    print(x_test)
    print(y_test)
    print(predictions)
    """
    score = accuracy_score(y_test, predictions)
    print(score)
    """
    print('Coefficients: \n', regr.coef_)
    print('Mean squared error: %.2f'
          % mean_squared_error(y_test, predictions))
    print('Coefficient of determination: %.2f'
          % r2_score(y_test, predictions))

    plot(x_train, x_test, y_train, y_test, predictions)


def digit():
    digits = datasets.load_digits()
    clf = svm.SVC(gamma=0.001, C=100.)

    x_train, x_test, y_train, y_test = train_test_split(digits.data, digits.target, test_size=0.2)
    clf.fit(x_train, y_train)
    predictions = clf.predict(x_test)
    score = accuracy_score(y_test, predictions)
    print(score)


def multiplication():
    df = pd.read_csv('test.csv')
    x = df.drop(columns=['z'])
    y = df['z']

    clf = svm.SVC(gamma=0.001, C=100.)

    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2)
    clf.fit(x_train, y_train)
    predictions = clf.predict(x_test)
    print(x_test.values)
    print(y_test.values)
    print(predictions)
    score = accuracy_score(y_test.values, predictions)
    print(score)


def ordinary_least_squares():
    regr = linear_model.LinearRegression()
    regr.fit([[0, 0], [1, 1], [2, 2]], [0, 1, 2])

    print(regr.coef_)


def ridge_regression():
    """
    regr = linear_model.Ridge(alpha=.5)
    regr.fit([[0, 0], [0, 0], [1, 1]], [0, .1, 1])

    print(regr.coef_)

    print(regr.intercept_)
    """

    df = pd.read_csv('test.csv')
    x = df.drop(columns=['z'])
    y = df['z']

    regr = linear_model.Ridge(alpha=.5)

    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2)
    regr.fit(x_train, y_train)
    predictions = regr.predict(x_test)

    # plot(x_train.x, x_test.x, x_train.y, x_test.y, predictions)

    print(x_test.values)
    print(y_test.values)
    print(predictions)


def age_classifier():
    df = pd.read_csv('test3.csv')
    x = df.drop(columns=['AgeGroup'])
    y = df['AgeGroup']

    clf = svm.SVC(gamma=0.001, C=100.)
    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2)

    clf.fit(x_train, y_train)

    predictions = clf.predict(x_test)

    print(predictions)
    print(y_test)

    print(clf.support_vectors_)
    print(clf.support_)
    print(clf.n_support_)


age_classifier()
