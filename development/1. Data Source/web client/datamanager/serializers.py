from rest_framework import serializers
from datamanager.models import Restaurant, Dish


class DishSerializer(serializers.ModelSerializer):
    restaurant_id = serializers.PrimaryKeyRelatedField(source='restaurant')

    class Meta:
        model = Dish
        fields = ('dish_id', 'restaurant_id', 'name', 'price', 'description')


class RestaurantSerializer(serializers.ModelSerializer):
    dishes = DishSerializer(many=True)

    class Meta:
        model = Restaurant
        fields = ('restaurant_id', 'name', 'address', 'phone_number', 'email_address', 'dishes')
