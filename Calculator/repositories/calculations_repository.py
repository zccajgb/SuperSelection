import pymongo
from functools import partial
from uuid import UUID as guid
import configparser as cp
import sys
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\models\\entities')
from selectivity_calculation_entity import SelectivityCalculationEntity


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

def update_db_item_full(calcs_db, calc):
    query_dict = { "_id": calc.calculation_id}
    calc_entity = SelectivityCalculationEntity(calc).__dict__
    set_string = { "$set": calc_entity}
    calcs_db.update_one(query_dict, set_string, upsert = False)

def getall_from_db(calcs_db):
    return calcs_db.find()

calcs_db = get_db('calculationsdb')

add = partial(add_to_db, calcs_db) 
getall = partial(getall_from_db, calcs_db)

update_db = partial(update_db_item_full, calcs_db)

    
