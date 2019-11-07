import pika
import sys
from functools import partial
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\models')
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\calculators')
sys.path.append('C:\\Users\\josep\\Dropbox\\PhD\\Source\\SuperSelection\\Calculator\\repositories')
from data import Data
from selectivity_calculation_model import SelectivityCalculationModel
from selectivity import calculate
from calculations_repository import update_db


def selectivity_callback(ch, method, properities, body):
    json = body.decode('utf8')
    data = Data(json)
    selectivity_model = SelectivityCalculationModel(data)
    selectivity_model = calculate(selectivity_model)
    update_db(selectivity_model)

controls = [
    ("Selectivity", selectivity_callback)
]

def setup_queue(channel, controls):
    (queue, callback) = controls
    channel.queue_declare(queue=queue)
    channel.basic_consume(queue=queue, auto_ack=True, on_message_callback=callback)

def setup_rabbitMQ(channel, controls):
    partial_setup = partial(setup_queue, channel)
    list(map(partial_setup, controls))
