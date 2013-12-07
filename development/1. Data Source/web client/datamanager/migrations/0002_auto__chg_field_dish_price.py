# -*- coding: utf-8 -*-
from south.utils import datetime_utils as datetime
from south.db import db
from south.v2 import SchemaMigration
from django.db import models


class Migration(SchemaMigration):

    def forwards(self, orm):

        # Changing field 'Dish.price'
        db.alter_column(u'datamanager_dish', 'price', self.gf('django.db.models.fields.DecimalField')(max_digits=5, decimal_places=2))

    def backwards(self, orm):

        # Changing field 'Dish.price'
        db.alter_column(u'datamanager_dish', 'price', self.gf('django.db.models.fields.DecimalField')(max_digits=3, decimal_places=2))

    models = {
        u'datamanager.dish': {
            'Meta': {'object_name': 'Dish'},
            'description': ('django.db.models.fields.TextField', [], {}),
            u'id': ('django.db.models.fields.AutoField', [], {'primary_key': 'True'}),
            'name': ('django.db.models.fields.CharField', [], {'max_length': '512'}),
            'price': ('django.db.models.fields.DecimalField', [], {'max_digits': '5', 'decimal_places': '2'}),
            'restaurant': ('django.db.models.fields.related.ForeignKey', [], {'to': u"orm['datamanager.Restaurant']"})
        },
        u'datamanager.restaurant': {
            'Meta': {'object_name': 'Restaurant'},
            'address': ('django.db.models.fields.TextField', [], {}),
            'email_address': ('django.db.models.fields.CharField', [], {'max_length': '128'}),
            u'id': ('django.db.models.fields.AutoField', [], {'primary_key': 'True'}),
            'name': ('django.db.models.fields.CharField', [], {'max_length': '256'}),
            'phone_number': ('django.db.models.fields.CharField', [], {'max_length': '64'})
        }
    }

    complete_apps = ['datamanager']