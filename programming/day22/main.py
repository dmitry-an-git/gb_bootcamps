from flask import Flask

app = Flask(__name__)

@app.route("/")
def main():
    return "Hello, world!"

@app.route("/index/<x>/<y>")
def index(x,y):
    return f"результат: {int(x)+int(y)}"
 
if __name__ == "__main__":
    app.run() 