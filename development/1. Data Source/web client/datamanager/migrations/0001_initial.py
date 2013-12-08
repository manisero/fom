# -*- coding: utf-8 -*-
from south.utils import datetime_utils as datetime
from south.db import db
from south.v2 import SchemaMigration
from django.db import models


class Migration(SchemaMigration):

    def forwards(self, orm):
        # Adding model 'Restaurant'
        db.create_table(u'datamanager_restaurant', (
            (u'id', self.gf('django.db.models.fields.AutoField')(primary_key=True)),
            ('name', self.gf('django.db.models.fields.CharField')(max_length=256)),
            ('address', self.gf('django.db.models.fields.TextField')()),
            ('phone_number', self.gf('django.db.models.fields.CharField')(max_length=64)),
            ('email_address', self.gf('django.db.models.fields.CharField')(max_length=128)),
        ))
        db.send_create_signal(u'datamanager', ['Restaurant'])

        # Adding model 'Dish'
        db.create_table(u'datamanager_dish', (
            (u'id', self.gf('django.db.models.fields.AutoField')(primary_key=True)),
            ('restaurant', self.gf('django.db.models.fields.related.ForeignKey')(related_name='dishes', to=orm['datamanager.Restaurant'])),
            ('name', self.gf('django.db.models.fields.CharField')(max_length=512)),
            ('price', self.gf('django.db.models.fields.DecimalField')(max_digits=5, decimal_places=2)),
            ('description', self.gf('django.db.models.fields.TextField')()),
        ))
        db.send_create_signal(u'datamanager', ['Dish'])


    def backwards(self, orm):
        # Deleting model 'Restaurant'
        db.delete_table(u'datamanager_restaurant')

        # Deleting model 'Dish'
        db.delete_table(u'datamanager_dish')


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
            u'id': ('django.db.models.fields.AutoField', [], {'primary_key': 'True'}),
            'name': ('django.db.models.fields.CharField', [], {'max_length': '256'}),
            'phone_number': ('django.db.models.fields.CharField', [], {'max_length': '64'})
        }
    }

    complete_apps = ['datamanager']