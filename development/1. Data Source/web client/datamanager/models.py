from django.db import models

# Create your models here.


class Restaurant(models.Model):
    name = models.CharField(max_length=256)
    phone_number = models.CharField(max_length=64)
