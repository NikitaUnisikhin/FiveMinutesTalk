// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function newField() {
    // определяем контейнер для хранения полей с вопросами
    let container = document.getElementById("questions");
    // получаем текущее количество input (полей для вопросов)
    let fieldCount = container.getElementsByTagName("input").length;
    // увеличиваем No для нового поля
    let nextFieldNo = fieldCount + 1;

    // здесь добавляем элемент, который будет хранить input (в моем случае, у вас может быть по другому или вообще не быть его)
    let div = document.createElement("div");
    div.setAttribute("class", "form-group");
    
    
    // создаем новое поле с новым id, name ДОЛЖЕН СОВПАДАТЬ С ИМЕНЕМ ПОЛЯ В МОДЕЛИ!!!
    let field = document.createElement("input");
    field.setAttribute("class", "form-control");
    field.setAttribute("id", "Questions[" + nextFieldNo + "]");
    field.setAttribute("name", "Questions");
    field.setAttribute("type", "text");
    field.setAttribute("placeholder", "Введите текст вопроса");

    // а здесь я своими кривыми ручками создаю номера вопросов
    const newContent = document.createTextNode(nextFieldNo + " ");
    div.appendChild(newContent);
    // добавляем поле в <div class="form-group"></div>
    div.appendChild(field);
    // добавляем <div class="form-group"><input ... /></div> в главный контейнер
    container.appendChild(div);
}