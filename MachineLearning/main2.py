import pandas as pd
from sklearn import linear_model
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split
from sklearn.naive_bayes import GaussianNB
from sklearn.feature_extraction.text import CountVectorizer
import seaborn as sns
import matplotlib.pylab as plt
import numpy as np

plt.style.use("seaborn")


# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.

# we need classification, Gausian is good for spam detection, let's use the simplest one
# i want 95% score
def gaussian_naive_bayes(x, y):
    gnb = GaussianNB()
    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2)

    gnb.fit(x_train, y_train)

    predictions = gnb.predict(x_test)

    # print(predictions)
    # print(y_test)

    score = accuracy_score(y_test, predictions)
    print("score: " + str(round(score * 100, 2)) + '%')


def test():
    # df = pd.read_csv(filepath_or_buffer="Data/SMSSpamCollection", sep="	", names=["Category", "Text"])
    # df.to_csv(path_or_buf="Data/SMSSpamCollection.csv", sep=",", index=False)
    df = pd.read_csv(filepath_or_buffer="Data/SMSSpamCollection.csv", sep=",")

    df_ham = df[df["Category"] == "ham"]
    df_spam = df[df["Category"] == "spam"]

    temp = df["Category"] == "spam"

    spam_percentage = str(round((df_spam.shape[0] / df.shape[0]) * 100, 2)) + '%'
    ham_percentage = str(round((df_ham.shape[0] / df.shape[0]) * 100, 2)) + '%'
    print("Spam: " + spam_percentage)
    print("Ham: " + ham_percentage)

    i: int = min(df_ham.shape[0], df_spam.shape[0])
    df = pd.concat([df_ham.sample(i), df_spam.sample(i)])

    df2 = pd.DataFrame(data=df["Category"] == "spam").rename(columns={"Category": "Spam"})
    # df2 = pd.concat([df, df2], axis=1)

    vectorizer = CountVectorizer()
    X = vectorizer.fit_transform(df["Text"])
    vectorizer.get_feature_names_out()

    x = pd.DataFrame(X.toarray())
    y = df2["Spam"]

    gaussian_naive_bayes(x, y)


def boxplot(df):
    df_red = df[df["blue_win"] == 0]
    df_blue = df[df["blue_win"] == 1]

    data_red_gold = [df_red['blueGold'], df_red['redGold']]
    data_blue_gold = [df_blue['blueGold'], df_blue['redGold']]
    column_names_gold = ['blueGold', 'redGold']
    data_red_level = [df_red['blueAvgLevel'], df_red['redAvgLevel']]
    data_blue_level = [df_blue['blueAvgLevel'], df_blue['redAvgLevel']]
    column_names_level = ['blueAvgLevel', 'redAvgLevel']

    fig, ax = plt.subplots(2)
    bp_red_gold = ax[0].boxplot(data_red_gold, positions=[1, 4], widths=0.35, patch_artist=True,
                                boxprops=dict(facecolor="#FF0000"))
    bp_blue_gold = ax[0].boxplot(data_blue_gold, positions=[2, 5], widths=0.35, patch_artist=True,
                                 boxprops=dict(facecolor="#0000FF"))

    bp_red_level = ax[1].boxplot(data_red_level, positions=[1, 4], widths=0.35, patch_artist=True,
                                 boxprops=dict(facecolor="#FF0000"))
    bp_blue_level = ax[1].boxplot(data_blue_level, positions=[2, 5], widths=0.35, patch_artist=True,
                                  boxprops=dict(facecolor="#0000FF"))

    ax[0].set_xticklabels(column_names_gold + column_names_gold)
    ax[1].set_xticklabels(column_names_level + column_names_level)

    ax[0].legend([bp_red_gold["boxes"][0], bp_blue_gold["boxes"][0]], ['RedWin', 'BlueWin'], loc='upper right')
    ax[1].legend([bp_red_level["boxes"][0], bp_blue_level["boxes"][0]], ['RedWin', 'BlueWin'], loc='upper right')

    for patch in bp_red_gold['boxes'] + bp_red_level['boxes']:
        patch.set_facecolor('#FF0000')

    for patch in bp_blue_gold['boxes'] + bp_blue_level['boxes']:
        patch.set_facecolor('#0000FF')

    plt.show()


def histogram(df):
    df_red = df[df["blue_win"] == 0]
    df_blue = df[df["blue_win"] == 1]

    # data_red_gold = [df_red['blueGold']
    # .apply(lambda j: round(j, 1000)), df_red['redGold'].apply(lambda j: round(j, 1000)]
    # df_red['blueGold'].apply(lambda j: round(j, 1000))
    # df_red['redGold'].apply(lambda j: round(j, 1000))
    data_red_gold = [df_red['blueGold'], df_red['redGold']]
    data_blue_gold = [df_blue['blueGold'], df_blue['redGold']]
    data_red_level = [df_red['blueAvgLevel'], df_red['redAvgLevel']]
    data_blue_level = [df_blue['blueAvgLevel'], df_blue['redAvgLevel']]

    fig, ax = plt.subplots(nrows=2, ncols=2)

    # bins = np.arange(min(data_red_gold[0] + data_red_gold[1]), max(data_red_gold[0] + data_red_gold[1]) + 1, 1000)
    bins = np.arange(min(data_red_gold[0] + data_red_gold[1]), max(data_red_gold[0] + data_red_gold[1]) + 1, 1000)

    colors = ['blue', 'red']

    bp_red_gold = ax[0, 0].hist(data_red_gold, color=colors, bins=10, label=colors)
    ax[0, 0].legend(prop={'size': 10})
    ax[0, 0].set_title('Gold on red win')
    bp_blue_gold = ax[0, 1].hist(data_blue_gold, color=colors, bins=10, label=colors)
    ax[0, 1].legend(prop={'size': 10})
    ax[0, 1].set_title('Gold on blue win')
    bp_red_level = ax[1, 0].hist(data_red_level, color=colors, bins=10, label=colors)
    ax[1, 0].legend(prop={'size': 10})
    ax[1, 0].set_title('Average level on red win')
    bp_blue_level = ax[1, 1].hist(data_blue_level, color=colors, bins=10, label=colors)
    ax[1, 1].legend(prop={'size': 10})
    ax[1, 1].set_title('Average level on blue win')

    # sns.displot(data_red_gold, )

    plt.show()


def heatmap(df):
    correlations = df.corr()
    plt.figure(figsize=(correlations.shape[0], correlations.shape[1]))
    heat_map = sns.heatmap(correlations, linewidth=1, annot=True, mask=np.triu(correlations))
    plt.show()


def pairplot(df):
    sns.pairplot(df, corner=True, diag_kind="kde")
    plt.show()


def test2():
    # df = pd.read_csv(filepath_or_buffer="Data/MatchTimelinesFirst15_100Entries.csv", sep=",")
    df = pd.read_csv(filepath_or_buffer="Data/MatchTimelinesFirst15.csv", sep=",")
    # df = df.drop(columns=[df.columns[0]])
    df = df.drop(columns=[df.columns[0], 'matchId', 'blueDragonKills', 'redDragonKills'])

    df_red = df[df["blue_win"] == 0]
    df_blue = df[df["blue_win"] == 1]

    i: int = min(df_red.shape[0], df_blue.shape[0])
    df = pd.concat([df_red.sample(i), df_blue.sample(i)])
    #boxplot(df)
    #histogram(df)
    #heatmap(df)
    #pairplot(df_red)
    #pairplot(df_blue)

    x = df[['blueGold', 'blueAvgLevel', 'redGold', 'redAvgLevel']]
    # x2 = df.drop(columns=['blue_win'])
    y = df['blue_win']
    gaussian_naive_bayes(x, y)


def ridge_regression(x, y):
    regr = linear_model.Ridge(alpha=.5)
    x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2)
    regr.fit(x_train, y_train)
    predictions = regr.predict(x_test)
    """
    print(x_test.values)
    print(y_test.values)
    print(predictions)
    """

    print(regr.coef_)
    print(regr.intercept_)
    df = pd.concat([x, y], axis=1)
    sns.pairplot(df, corner=True, diag_kind="kde")
    plt.show()
    """
    score = accuracy_score(y_test.values, predictions)
    print("score: " + str(round(score * 100, 2)) + '%')
    """


def test3():
    df = pd.read_csv(filepath_or_buffer="Data/winequality-red.csv", sep=";")
    df4 = df[df["quality"] == 4]
    df5 = df[df["quality"] == 5]
    df6 = df[df["quality"] == 6]
    df7 = df[df["quality"] == 7]
    i = min(df4.shape[0], df5.shape[0], df6.shape[0], df7.shape[0])
    df = pd.concat([df4.sample(i), df5.sample(i), df6.sample(i), df7.sample(i)])
    x = df.drop(columns=['quality'])
    y = df['quality']
    ridge_regression(x, y)
    heatmap(df)


def print_hi(name):
    # Use a breakpoint in the code line below to debug your script.
    print(f'Hi, {name}')  # Press Ctrl+F8 to toggle the breakpoint.


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    print_hi('PyCharm')
    test2()

# See PyCharm help at https://www.jetbrains.com/help/pycharm/
