import random
from pathlib import Path

import matplotlib.pyplot as plt
import numpy as np
import pandas as pd
import seaborn as sns
from mpl_toolkits.mplot3d import Axes3D
from sklearn import linear_model, datasets, svm, tree
from sklearn.cluster import KMeans
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.feature_selection import VarianceThreshold
from sklearn.metrics import accuracy_score, mean_squared_error, r2_score, precision_score, recall_score
from sklearn.model_selection import train_test_split
from sklearn.naive_bayes import GaussianNB
from sklearn.neighbors import NearestNeighbors
from sklearn.svm import LinearSVC
from sklearn.tree import DecisionTreeClassifier


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

    plt.scatter(x_test, y_test, color='black')
    plt.scatter(x_train, y_train, color='green')
    plt.plot(x_test, predictions, color='blue', linewidth=5)

    """
    plt.xticks(())
    plt.yticks(())
    """

    plt.show()


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

    """
    plt.scatter(x_test['x'], x_test['y'], color='black')
    plt.scatter(x_train['x'], x_train['y'], color='green')
    plt.plot(x_test, predictions, color='blue', line_width=5)
    """
    """
    plt.xticks(())
    plt.yticks(())
    """

    fig = plt.figure(2)
    ax = Axes3D(fig, elev=-150, azim=110)
    ax.scatter(x_test['x'], x_test['y'], y_test, c='black')
    ax.scatter(x_train['x'], x_train['y'], y_train, c='green')

    ax.scatter(x_test['x'], x_test['y'], predictions, c='red')

    ax.set_xlabel('x')
    ax.set_ylabel('y')
    ax.set_zlabel("z")

    plt.show()


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

    plt.figure()

    plt.scatter(x_test['x'], x_test['y'], c='black')
    plt.scatter(x_train['x'], x_train['y'], c='green')

    plt.show()


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


def obesity_classifier():
    df = pd.read_csv('Data/500_Person_Gender_Height_Weight_Index.csv')
    x = df.drop(columns=['Gender', 'Index'])
    y = df['Index']

    clf = svm.SVC(gamma=0.001, C=100.)
    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2)

    plt.figure(1)

    plt.scatter(x_test['Height'], x_test['Weight'], c='black')
    plt.scatter(x_train['Height'], x_train['Weight'], c='green')

    plt.xlabel('Height')
    plt.ylabel('Weight')

    clf.fit(x_train, y_train)

    predictions = clf.predict(x_test)

    print(predictions)
    print(y_test)

    score = accuracy_score(y_test, predictions)
    print(score)

    fig = plt.figure(2)
    ax = Axes3D(fig, elev=-150, azim=110)
    ax.scatter(x_test['Height'], x_test['Weight'], y_test, c='black')
    ax.scatter(x_train['Height'], x_train['Weight'], y_train, c='green')

    ax.scatter(x_test['Height'], x_test['Weight'], predictions, c='red')

    ax.set_xlabel('Height')
    ax.set_ylabel('Weight')
    ax.set_zlabel("Obesity")

    plt.show()


def gaussian_naive_bayes():
    df = pd.read_csv('Data/500_Person_Gender_Height_Weight_Index.csv')
    x = df.drop(columns=['Gender', 'Index'])
    y = df['Index']

    gnb = GaussianNB()

    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2)

    gnb.fit(x_train, y_train)

    predictions = gnb.predict(x_test)

    fig = plt.figure(2)
    ax = Axes3D(fig, elev=-150, azim=110)
    ax.scatter(x_test['Height'], x_test['Weight'], y_test, c='black')
    ax.scatter(x_train['Height'], x_train['Weight'], y_train, c='green')

    ax.scatter(x_test['Height'], x_test['Weight'], predictions, c='red')

    ax.set_xlabel('Height')
    ax.set_ylabel('Weight')
    ax.set_zlabel("Obesity")

    score = accuracy_score(y_test, predictions)
    print(score)

    plt.show()


def nearest_neighbor():
    # x = np.array([[-1, -1], [-2, -1], [-3, -2], [1, 1], [2, 1], [3, 2]])
    # x = np.array([[-1, -1], [-2, -1], [-3, -2], [-1, 0], [1, 1], [2, 1], [3, 2], [0, 0]])
    # x = np.array([[-1, -1], [-2, -1], [-3, -2]])
    # x = [[-1, -1], [-2, -1], [-3, -2], [-1, 0], [1, 1], [2, 1], [3, 2], [0, 0]]
    # x = [[-1, -1], [-2, -1], [-3, -3], [-1, 0], [1, 1], [2, 2], [3, 3], [0, 0]]
    # x = [[-2, 1], [0, 2], [1, 3], [-1, -3], [3, 1], [0, 3], [1, -1], [2, 3], [3, 1], [3, -2]]

    x = get_random_coordinates(10, -3, 3, -3, 3)

    nbrs = NearestNeighbors(n_neighbors=2, algorithm='ball_tree').fit(x)
    nbrs_matrix = list(nbrs.kneighbors_graph(x).toarray())
    print(x)

    for i in range(len(x)):
        # plt.scatter(x[i, 0], x[i, 1], color='black')
        plt.scatter(x[i][0], x[i][1], color='black')

    for i in [list(i) for i in nbrs_matrix]:
        pos1 = i.index(1.)
        i[pos1] = 0
        pos2 = i.index(1.)
        """
        if x[pos1][1] < x[pos2][1] and x[pos1][0] >= x[pos2][0]:
            plt.plot(x[pos1], x[pos2], color='blue', linewidth=5)
        else:
            plt.plot(x[pos2], x[pos1], color='green', linewidth=5)
        """
        """
        if x[pos1][0] == 0 or x[pos1][1] == 0 or x[pos2][0] == 0 or x[pos2][1] == 0:
            plt.plot(x[pos1], x[pos2], color='blue', linewidth=5)
        else:
            plt.plot(x[pos2], x[pos1], color='green', linewidth=5)
            # plt.plot(x[pos1], x[pos2], color='red', linewidth=5)
        """
        plt.plot([x[pos1][0], x[pos2][0]], [x[pos1][1], x[pos2][1]], color='green', linewidth=5)

    # plt.plot(x[0], x[1])
    """
    print(temp)
    print(x[2]+ temp[2])
    """

    """
    # for i in range(len(x)):
    plt.plot(x[2], x[2] + temp[2], color='blue', linewidth=5)
    """

    plt.xlabel('x')
    plt.ylabel('y')

    plt.show()


def get_random_coordinates(amount, xmin, xmax, ymin, ymax):
    arr = []
    y = [random.randint(xmin, xmax), random.randint(ymin, ymax)]
    for x in range(amount):
        while arr.__contains__(y):
            y = [random.randint(xmin, xmax), random.randint(ymin, ymax)]
        arr.append(y)
    return arr


def k_means():
    df = pd.read_csv('Data/500_Person_Gender_Height_Weight_Index.csv')
    x = df.drop(columns=['Gender', 'Index'])
    # y = df['Index']

    km = KMeans(n_clusters=8).fit(x.values)

    plt.figure(1)

    plt.scatter(x['Height'], x['Weight'], c='black')
    for i in km.cluster_centers_:
        plt.scatter(i[0], i[1], c='green')

    plt.xlabel('Height')
    plt.ylabel('Weight')

    plt.show()


def obesity_cluster():
    df = pd.read_csv('Data/500_Person_Gender_Height_Weight_Index.csv')
    x = df.drop(columns=['Gender'])

    km = KMeans(n_clusters=8).fit(x.values)

    fig = plt.figure(2)
    ax = Axes3D(fig, elev=-150, azim=110)
    ax.scatter(x['Height'], x['Weight'], x['Index'], c='black')
    for i in km.cluster_centers_:
        ax.scatter(i[0], i[1], i[2], c='green')

    ax.set_xlabel('Height')
    ax.set_ylabel('Weight')
    ax.set_zlabel("Obesity")

    plt.show()


def heatmap(df):
    correlations = df.corr()
    plt.figure(figsize=(correlations.shape[0], correlations.shape[1]))
    _ = sns.heatmap(correlations, linewidth=1, annot=True, mask=np.triu(correlations))
    plt.show()


def pairplot(df, hue=None):
    sns.pairplot(df, corner=True, diag_kind="kde", hue=hue)
    plt.show()


# def school_grades():
#     df = pd.read_csv('Data/school_grades_dataset.csv')
#     X = df[["school", "sex", "age", "address", "Pstatus", "Medu", "Fedu", "Mjob", "Fjob", "studytime", "failures",
#             "schoolsup", "famsup", "paid", "activities", "nursery", "higher", "internet", "romantic", "famrel",
#             "freetime", "goout", "Dalc", "Walc", "absences", "G1", "G2", "G3"]]
#     # temp = X[X["failures"] > 0]
#     # temp = temp[["G1", "G2", "G3", "failures"]]
#     # pairplot(temp)
#     # temp2 = X[X["failures"] == 0]
#     # temp2 = temp2[["G1", "G2", "G3"]]
#     # pairplot(X[["G1", "G2", "G3", "failures"]], "failures")
#     heatmap(df)


def vectorize_column(column, df):
    vectorizer = CountVectorizer(analyzer='char')
    X = vectorizer.fit_transform(df[column])

    names = []
    for item in vectorizer.get_feature_names_out():
        names.append(column + "-" + str(item))
    return pd.DataFrame(X.toarray(), columns=names, index=df.axes[0].values)


def decision_tree(X, y, class_names):
    # model = DecisionTreeClassifier(max_depth=6, min_samples_leaf=10)
    model = DecisionTreeClassifier()
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.5)
    model = model.fit(X_train, y_train)
    y_predict = model.predict(X_test)
    # y_predict_prob = model.predict_proba(X_test)

    print("accuracy:", accuracy_score(y_test, y_predict))
    print("precision:", precision_score(y_test, y_predict))
    print("recall:", recall_score(y_test, y_predict))

    fig, axes = plt.subplots(nrows=1, ncols=1, figsize=(4, 4), dpi=300)
    tree.plot_tree(model, feature_names=X.columns, class_names=class_names, filled=True)
    # tree.plot_tree(model, feature_names=X.columns)
    # r = export_text(model, feature_names=X.columns)
    # print(r)
    # ft_importance = pd.Series(model.feature_importances_, index=X.columns).sort_values()
    plt.show()


def linear_svc(X, y):
    model = LinearSVC()
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.5)
    model = model.fit(X_train, y_train)
    y_predict = model.predict(X_test)
    print("accuracy:", accuracy_score(y_test, y_predict))
    print("precision:", precision_score(y_test, y_predict))
    print("recall:", recall_score(y_test, y_predict))


def mushroom_refit(file):
    df_CSV = pd.read_csv(file + '.csv')

    for item in df_CSV.columns:
        if item == "eatability":
            df["poisoned"] = (df_CSV["eatability"] == "p").astype(int)
        elif item == "bruises":
            df["bruised"] = (df_CSV["bruises"] == "t").astype(int)
        else:
            temp = vectorize_column(item, df_CSV)
            df = pd.concat([df, temp], axis=1)

    # df.rename(columns={'eatability': 'poisoned', 'bruises': 'bruised'}, inplace=True)

    df.to_csv(path_or_buf= file + "-refit.csv", sep=",", index=False)


def mushrooms_decision_tree():
    df = pd.DataFrame()
    if not Path("Data/agaricus-lepiota-refit.csv").is_file():
        mushroom_refit("Data/agaricus-lepiota")
    else:
        df = pd.read_csv('Data/agaricus-lepiota-refit.csv')

    X = df.drop(columns=["poisoned", "stalk-root-?", "bruised"])
    y = df["poisoned"]

    sel = VarianceThreshold(threshold=(.8 * (1 - .8)))
    X2 = sel.fit_transform(X)
    X2 = pd.DataFrame(X2, index=X.axes[0].values, columns=sel.get_feature_names_out())

    decision_tree(X, y, ["Safe", "Poisonous"])
    decision_tree(X2, y, ["Safe", "Poisonous"])
    # heatmap(pd.concat([X, y], axis=1))

    # param_grid = {
    #     'max_depth': [5, 15, 25],
    #     'min_samples_leaf': [1, 3, 10, 15, 20, 50],
    #     'max_leaf_nodes': [10, 20, 35, 50]}
    # dt = DecisionTreeClassifier()
    # gs = GridSearchCV(dt, param_grid, scoring='f1', cv=5)
    # gs.fit(X, y)
    # print("best params X: ", gs.best_params_)
    # gs.fit(X2, y)
    # print("best params X2: ", gs.best_params_)


def mushroom_linear_svc():
    df = pd.DataFrame()
    if not Path("Data/agaricus-lepiota-refit.csv").is_file():
        mushroom_refit("Data/agaricus-lepiota")
    else:
        df = pd.read_csv('Data/agaricus-lepiota-refit.csv')

    X = df.drop(columns=["poisoned", "stalk-root-?", "bruised"])
    y = df["poisoned"]

    sel = VarianceThreshold(threshold=(.8 * (1 - .8)))
    X2 = sel.fit_transform(X)
    X2 = pd.DataFrame(X2, index=X.axes[0].values, columns=sel.get_feature_names_out())
    linear_svc(X, y)
    linear_svc(X2, y)


mushrooms_decision_tree()
