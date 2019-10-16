import pymongo
from functools import partial
from uuid import uuid4 as guid

def calcs_db(host, db, collection):
    client = pymongo.MongoClient("mongodb://localhost:27017/")
    db = client["CalculationsDb"]
    calcs = db["Calculations"]
    return calcs

def add_to_db(calcs_db, calc):
    calcs_db.insert_one(vars(calc))

calcs_db = calcs_db("mongodb://localhost:27017/", "CalculationsDb", "Calculations")

add = partial(add_to_db, calcs_db)