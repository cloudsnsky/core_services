import os
from connexion.resolver import RestyResolver
import connexion
from flask_injector import FlaskInjector
from injector import Binder

from services.backup_service import BackupService

def configure(binder: Binder) -> Binder:
    binder.bind(
        BackupService, 
        to=BackupService
    )

if __name__ == '__main__':
    app = connexion.App(__name__, specification_dir='swagger/')
    app.add_api('api_swagger.yaml', resolver=RestyResolver('apis'))
    FlaskInjector(app=app.app, modules=[configure])
    SERVER_PORT = os.environ.get("SERVER_PORT", default=9090)
    app.run(port=SERVER_PORT)
