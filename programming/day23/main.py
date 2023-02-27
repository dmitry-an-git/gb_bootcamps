
# file = open('gb_bootcamps/programming/day23/file.txt', 'r', encoding='utf-8')

# result_data = list()
# for line in file.readlines():
#     result_data.append(tuple(line.split("\n")[0].split(';')))

# file.close()

# print(result_data)

from flask import Flask, render_template
from random import randint as rd

app = Flask(__name__)

@app.route("/")
@app.route("/index")
def main():
    with open('gb_bootcamps/programming/day23/file.txt', 'r', encoding='utf-8') as file:
        result_data = list()
        for line in file.readlines():
            result_data.append(tuple(line.split("\n")[0].split(';')))

    return render_template("base.html", data=result_data)

@app.route('/about')
def about():
    return render_template('about.html')

if __name__ == "__main__":
    app.run() 