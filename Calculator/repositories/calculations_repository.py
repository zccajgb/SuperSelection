import pymongo
from functools import partial
from uuid import uuid4 as guid
import configparser as cp

def get_db(configString):
    config = cp.ConfigParser()
    config.read('db.ini')
    config = config[configString]
    client = pymongo.MongoClient(config['host'])
    db = client[config['db']]
    calcs = db[config['collection']]
    return calcs

def add_to_db(calcs_db, calc):
    calcs_db.insert_one(vars(calc))

def getall_from_db(calcs_db):
    return calcs_db.find()

calcs_db = get_db('calculationsdb')

add = partial(add_to_db, calcs_db) 
getall = partial(getall_from_db, calcs_db)

    
