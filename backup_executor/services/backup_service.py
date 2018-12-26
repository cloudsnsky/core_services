from datetime import datetime
from os import makedirs
from os.path import join
from os.path import dirname
import json
from pymongo import MongoClient
from bson.json_util import dumps

class BackupService(object):
    '''
    Backup database service
    '''
    LOCAL_STORAGE = '/backup_storage'
    def mongodb_backup(self, connection_string, database, destination):
        '''
        Run backup the database to a specific destination
        '''
        client = MongoClient(connection_string)
        database = client[database]
        collections = database.list_collection_names()
        if destination['type'] == 'local':
            self.__write_collections(database, collections, destination['path'])

    def __write_collections(self, database, collections, path):
        datetime_directory = datetime.now().strftime('%Y%m%d%H%M%S')
        for index, collection_name in enumerate(collections):
            collection = getattr(database, collections[index])
            documents = collection.find()
            jsonfilename = '{0}.json'.format(collection_name)
            jsonfilepath = join(self.LOCAL_STORAGE, path, datetime_directory, jsonfilename)
            makedirs(dirname(jsonfilepath), exist_ok=True)
            with open(jsonfilepath, 'w') as jsonfile:
                jsonfile.write(dumps(documents))  
