import time

def resize_image(image):
    start_time = time.perf_counter()
    end_time = time.perf_counter()
    print(f"Время выполнения resize_image: {end_time - start_time:.10f} секунд")

def rotate_image(image):
    start_time = time.perf_counter()
    end_time = time.perf_counter()
    print(f"Время выполнения rotate_image: {end_time - start_time:.10f} секунд")

def save_image(image, filename):
    start_time = time.perf_counter()
    end_time = time.perf_counter()
    print(f"Время выполнения save_image: {end_time - start_time:.10f} секунд")

image = "C:/Users/Home/Pictures/пук/Мемы-про-пиво-004.jpg"  # Замените на объект вашего изображения

resize_image(image)
rotate_image(image)
save_image(image, "output.jpg")
