class Car:
    def __init__(self, maker: str, model: str, year: int, fuel_capacity: float, fuel_consumption: float):
        self._maker = maker
        self._model = model
        self._year = year
        self._mileage = 0
        self.__fuel_level = fuel_capacity
        self.__fuel_capacity = fuel_capacity
        self.__fuel_consumption = fuel_consumption

    def get_description(self):
        """Returns a description string"""
        return str(self._year) + ' ' + self._maker.capitalize() + ' ' + self._model.capitalize()

    def look_at_odometer(self):
        """Gets the value of odometer"""
        return self._mileage

    def drive(self, increment: float):
        if increment > 0 and (isinstance(increment, float) or isinstance(increment, int)):
            if increment*self.__fuel_consumption < self.__fuel_level:
                self._mileage += increment
                self.__fuel_level -= increment*self.__fuel_consumption

    def __fuel_car(self, increment: float):
        if increment > 0 and (isinstance(increment, float) or isinstance(increment, int)):
            self.__fuel_level += increment


class Electric_car(Car):
    """Derived class from Car"""
    def __init__(self, maker: str, model: str, year: int, battery_capacity: float, battery_consumption: float):
        super().__init__(maker, model, year)
        self.battery = Battery(battery_capacity, battery_consumption)

    def measure_electricity(self):
        return self.battery.battery_level

    def drive(self, increment: float):
        if increment > 0 and (isinstance(increment, float) or isinstance(increment, int)):
            if increment * self._battery_consumption < self._battery_level:
                self._mileage += increment
                self._battery_level -= increment * self._battery_consumption


class Battery:
    def __init__(self, battery_capacity: float, battery_consumption: float):
        self.battery_capacity = battery_capacity
        self.battery_level = battery_capacity
        self.battery_consumption = battery_consumption

    def charge_battery(self, increment: float):
        if increment > 0 and (isinstance(increment, float) or isinstance(increment, int)):
            self.battery_level += increment