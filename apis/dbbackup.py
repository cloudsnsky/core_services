import uuid
from flask_injector import inject

from services.backup_service import BackupService

class DbBackup(object):

    @inject
    def post(self, service: BackupService, dbbackup: dict):
        '''
        This will trigger a backup job.
        The return data is the backup job data with id included.
        '''

        # Generates a unique ID for backup job
        dbbackup['id'] = str(uuid.uuid4())

        print(dbbackup)
        dbtype = dbbackup['dbtype']
        if dbtype == 'mssql':
            #mssql_backup(data)
            pass
        elif dbtype == 'mongodb':
            service.mongodb_backup(dbbackup['connection_string'], dbbackup['dbname'], dbbackup['destination'])
        else:
            # log
            pass
        return dbbackup
class_instance = DbBackup()
