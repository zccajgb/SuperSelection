from calculator_controller import controls, setup_rabbitMQ
import pika

channel = pika.BlockingConnection(pika.ConnectionParameters('localhost')).channel()
setup_rabbitMQ(channel, controls)
channel.start_consuming()