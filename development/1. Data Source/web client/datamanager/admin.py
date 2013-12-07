from django.contrib import admin

# Register your models here.
from datamanager.models import Restaurant, Dish

admin.site.register(Restaurant)
admin.site.register(Dish)
