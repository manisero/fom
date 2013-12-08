# -*- coding: utf-8 -*-
from django.db import models

# Create your models here.


class Restaurant(models.Model):
    name = models.CharField(max_length=256)
    address = models.TextField()
    phone_number = models.CharField(max_length=64)
    email_address = models.CharField(max_length=128)

    def __unicode__(self):
        return self.name


class Dish(models.Model):
    restaurant = models.ForeignKey('Restaurant', related_name='dishes')
    name = models.CharField(max_length=512)
    price = models.DecimalField(max_digits=5, decimal_places=2)
    description = models.TextField()

    def __unicode__(self):
        return self.name + u' za: ' + str(self.price) + u' zł'

