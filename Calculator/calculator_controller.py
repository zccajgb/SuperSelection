import pika
import SelectivityAndActivity, Test
from functools import partial

controls = [
    ("test", Test.test_callback),
    ("SelectivityAndActivityCalculations", SelectivityAndActivity.selectivity_and_activity_callback)
]

def setup_queue(channel, controls):
    (queue, callback) = controls
    channel.queue_declare(queue=queue)
    channel.basic_consume(queue=queue, auto_ack=True, on_message_callback=callback)

def setup_rabbitMQ(channel, controls):
    partial_setup = partial(setup_queue, channel)
    list(map(partial_setup, controls))



