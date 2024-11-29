from PIL import Image

class ImageHandler:
    def __init__(self):
        self.image = None
        self.image_path = None

    def load_image(self, path):
        self.image_path = path
        self.image = Image.open(path)
        return self.image

    def resize_image(self, width, height):
        if self.image:
            self.image = self.image.resize((width, height))
            return self.image
        raise ValueError("Изображение не загружено.")

    def rotate_image(self, angle):
        if self.image:
            self.image = self.image.rotate(angle)
            return self.image
        raise ValueError("Изображение не загружено.")

    def save_image(self, path):
        if self.image:
            self.image.save(path)
