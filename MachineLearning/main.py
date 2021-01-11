import pandas as pd
from sklearn.tree import DecisionTreeRegressor
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score

df = pd.read_csv('test.csv')

x = df.drop(columns=['anzsic_descriptor', 'gas', 'units', 'magnitude', 'data_val'])
y = df['data_val']
x_train, x_test, y_train, y_test = train_test_split(x, y, test_size=0.2)

model = DecisionTreeRegressor()
model.fit(x_train, y_train)
predictions = model.predict(x_test)

# score = accuracy_score(y_test, predictions)
print(y_test.values)
print(predictions)

testarr = []
predictarr = []

for x in range(y_test.values.size):
    y_test.values[x] = int(round(y_test.values[x]))
    # testarr.append(int(round(y_test.values[x])))

for x in range(predictions.size):
    predictions[x] = int(round(predictions[x]))
    # predictarr.append(int(round(predictions[x])))

print(y_test.values)
print(predictions)
score = accuracy_score(y_test, predictions)
print(score)
