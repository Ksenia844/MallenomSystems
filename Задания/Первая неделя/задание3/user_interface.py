from PyQt5.QtWidgets import (QMainWindow, QPushButton, QLabel,
                             QVBoxLayout, QHBoxLayout,
                             QWidget, QFileDialog, QMessageBox, QInputDialog)
from PyQt5.QtGui import QPixmap, QTransform
from PyQt5.QtCore import Qt
from image_handler import ImageHandler

class UserInterface(QMainWindow):
    def __init__(self):
        super().__init__()
        self.image_handler = ImageHandler()
        self.init_ui()

    def init_ui(self):
        self.setWindowTitle("Утилита работы с изображениями, Аксёнова Ксения Максимовна")
        self.setGeometry(100, 100, 800, 600)  # Установка начального размера окна

        # Основной виджет и макет
        central_widget = QWidget()
        self.setCentralWidget(central_widget)
        layout = QVBoxLayout(central_widget)

        # Верхний горизонтальный макет для кнопок
        button_layout = QHBoxLayout()

        # Кнопки
        load_button = QPushButton("Загрузить изображение")
        load_button.clicked.connect(self.load_image)
        button_layout.addWidget(load_button)

        resize_button = QPushButton("Изменить размер изображения")
        resize_button.clicked.connect(self.resize_image)
        button_layout.addWidget(resize_button)

        rotate_button = QPushButton("Повернуть изображение")
        rotate_button.clicked.connect(self.rotate_image)
        button_layout.addWidget(rotate_button)

        apply_button = QPushButton("Сохранить изображение")
        apply_button.clicked.connect(self.save_image)
        button_layout.addWidget(apply_button)

        layout.addLayout(button_layout)

        # Блок информации
        self.info_label = QLabel("Информация о действиях:")
        layout.addWidget(self.info_label)

        # Метка для отображения изображения
        self.image_label = QLabel()
        layout.addWidget(self.image_label)

    def load_image(self):
        path, _ = QFileDialog.getOpenFileName(self, "Выберите изображение", "", "Image Files (*.png *.jpg *.jpeg *.gif)")
        if path:
            try:
                self.image_handler.load_image(path)
                pixmap = QPixmap(path)
                self.image_label.setPixmap(pixmap.scaled(400, 400, Qt.KeepAspectRatio))
                self.info_label.setText(f"Загружено: {path}")
            except Exception as e:
                QMessageBox.critical(self, "Ошибка", str(e))

    def resize_image(self):
        size, ok = QInputDialog.getText(self, "Изменить размер", "Введите новый размер (ширина, высота):")
        if ok and size:
            try:
                width, height = map(int, size.split(","))
                self.image_handler.resize_image(width, height)
                pixmap = QPixmap(self.image_handler.image_path)
                pixmap = pixmap.scaled(width, height, Qt.KeepAspectRatio)
                self.image_label.setPixmap(pixmap)
                self.info_label.setText(f"Изображение изменено до: {width}x{height}.")
            except Exception as e:
                QMessageBox.critical(self, "Ошибка", str(e))

    def rotate_image(self):
        angle, ok = QInputDialog.getInt(self, "Повернуть изображение", "Введите угол поворота:")
        if ok:
            try:
                self.image_handler.rotate_image(angle)
                pixmap = QPixmap(self.image_handler.image_path)
                pixmap = pixmap.transformed(QTransform().rotate(angle))
                self.image_label.setPixmap(pixmap.scaled(400, 400, Qt.KeepAspectRatio))
                self.info_label.setText(f"Изображение повернуто на: {angle} градусов.")
            except Exception as e:
                QMessageBox.critical(self, "Ошибка", str(e))

    def save_image(self):
        if self.image_handler.image_path:
            save_path, _ = QFileDialog.getSaveFileName(self, "Сохранить изображение", "", "Image Files (*.png *.jpg *.jpeg)")
            if save_path:
                try:
                    self.image_handler.save_image(save_path)
                    self.info_label.setText(f"Изображение сохранено: {save_path}")
                except Exception as e:
                    QMessageBox.critical(self, "Ошибка", str(e))
        else:
            QMessageBox.warning(self, "Предупреждение", "Нет загруженного изображения для сохранения.")
