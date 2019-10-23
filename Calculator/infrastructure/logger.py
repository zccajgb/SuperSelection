import logging

def init_log():
    logging.basicConfig(filename='app.log', filemode='w', format='%(name)s  [%(levelname    )s]  %(message)s')
    logger = logging.getLogger("Calculator")
    return logger