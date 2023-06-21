import { newField, changeComponents, removeParent } from './site.js';

// Подключение кнопки добавления к функции
document.querySelector('#AddQuestion1').addEventListener('click', function (ev) {
    newField(ev)
});

// Подключение изначального select к функции
document.querySelector('select').addEventListener('change', function (questionType) {
    changeComponents(questionType)
});

// Подключение кнопки закрытия к функции
document.querySelector(".close-button").addEventListener('click', removeParent);
