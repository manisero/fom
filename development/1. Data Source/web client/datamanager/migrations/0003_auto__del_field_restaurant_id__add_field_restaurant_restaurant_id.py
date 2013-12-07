# -*- coding: utf-8 -*-
from south.utils import datetime_utils as datetime
from south.db import db
from south.v2 import SchemaMigration
from django.db import models


class Migration(SchemaMigration):

    def forwards(self, orm):
        # Deleting field 'Restaurant.id'
        db.delete_column(u'datamanager_restaurant', u'id')

        # Adding field 'Restaurant.restaurant_id'
        db.add_column(u'datamanager_restaurant', 'restaurant_id',
                      self.gf('django.db.models.fields.AutoField')(default=0, primary_key=True),
                      keep_default=False)


    def backwards(self, orm):

        # User chose to not deal with backwards NULL issues for 'Restaurant.id'
        raise RuntimeError("Cannot reverse this migration. 'Restaurant.id' and its values cannot be restored.")
        
        # The following code is provided here to aid in writing a correct migration        # Adding field 'Restaurant.id'
        db.add_column(u'datamanager_restaurant', u'id',
                      self.gf('django.db.models.fields.AutoField')(primary_key=True),
                      keep_default=False)

        # Deleting field 'Restaurant.restaurant_id'
        db.delete_column(u'datamanager_restaurant', 'restaurant_id')


    models = {
        u'datamanager.dish': {
            'Meta': {'object_name': 'Dish'},
            'description': ('django.db.models.fields.TextField', [], {}),
            u'id': ('django.db.models.fields.AutoField', [], {'primary_key': 'True'}),
            'name': ('django.db.models.fields.CharField', [], {'max_length': '512'}),
            'price': ('django.db.models.fields.DecimalField', [], {'max_digits': '5', 'decimal_places': '2'}),
            'restaurant': ('django.db.models.fields.related.ForeignKey', [], {'related_name': "'dishes'", 'to': u"orm['datamanager.Restaurant']"})
        },
        u'datamanager.restaurant': {
            'Meta': {'object_name': 'Restaurant'},
            'address': ('django.db.models.fields.TextField', [], {}),
            'email_address': ('django.db.models.fields.CharField', [], {'max_length': '128'}),
            'name': ('django.db.models.fields.CharField', [], {'max_length': '256'}),
            'phone_number': ('django.db.models.fields.CharField', [], {'max_length': '64'}),
            'restaurant_id': ('django.db.models.fields.AutoField', [], {'default': '0', 'primary_key': 'True'})
        }
    }

    complete_apps = ['datamanager']