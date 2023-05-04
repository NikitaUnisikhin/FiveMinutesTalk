// Перенес сюда подключение кнопки добавления к функции, т.к. писать onclick в html плохая практика
let addQuestion = document.querySelector('#add-question');
addQuestion.addEventListener('click', newField);

// Я предлагаю сделать глобальный id для вопросов, чтобы после удаления у нас не было совпадений id вопросов
let questionId = 1;
newField();
function newField() {
    // определяем контейнер для хранения полей с вопросами
    let container = document.getElementById("questions");
    // получаем текущее количество input (полей для вопросов)
    let fieldCount = container.getElementsByClassName("form-group").length;
    // увеличиваем No для нового поля
    let nextFieldNo = fieldCount + 1;

    // здесь добавляем элемент, который будет хранить input
    let div = document.createElement("div");
    div.setAttribute("class", "form-group");

    // создаем новое поле с новым id, name ДОЛЖЕН СОВПАДАТЬ С ИМЕНЕМ ПОЛЯ В МОДЕЛИ!!!
    let field = document.createElement("input");
    field.setAttribute("class", "form-control");
    field.setAttribute("id", "Questions[" + questionId + "]");
    field.setAttribute("name", "Questions");
    field.setAttribute("type", "text");
    field.setAttribute("asp-for", "Text");
    field.setAttribute("placeholder", "Введите текст вопроса");
    field.setAttribute("value", "Название");

    // а здесь я своими кривыми ручками создаю номера вопросов
    const questionNumber = document.createTextNode(String(nextFieldNo));
    div.appendChild(questionNumber);

    // Здесь создаем выбор типа вопроса
    let lbl = document.createElement("label");
    let spn = document.createElement("span");
    let questionType = document.createElement("select");
    questionType.id = String(questionId);

    // создаем options для select
    // изменил обратно, чтобы была возможность добавить аттрибут для типа вопросов
    let opt1 = document.createElement("option");
    opt1.setAttribute("value", "0");
    let nod1 = document.createTextNode("Текст");
    opt1.appendChild(nod1);

    let opt2 = document.createElement("option");
    opt2.setAttribute("value", "1");
    let nod2 = document.createTextNode("Код");
    opt2.appendChild(nod2);

    let opt3 = document.createElement("option");
    opt3.setAttribute("value", "2");
    let nod3 = document.createTextNode("Один из списка");
    opt3.appendChild(nod3);

    let opt4 = document.createElement("option");
    opt4.setAttribute("value", "3");
    let nod4 = document.createTextNode("Несколько из списка");
    opt4.appendChild(nod4);

    // добавляем options
    questionType.appendChild(opt1);
    questionType.appendChild(opt2);
    questionType.appendChild(opt3);
    questionType.appendChild(opt4);

    // При изменении типа будем менять компонеты вопроса
    questionType.addEventListener('change', function (questionType) {
        changeComponents(questionType)
    });

    lbl.appendChild(questionType);
    lbl.appendChild(spn);

    // добавляем всё это в div
    div.appendChild(lbl);

    // Здесь создаю кнопку для удаления вопроса
    let close = document.createElement("button");
    close.setAttribute("class", "close-button");
    close.addEventListener('click', removeParent);
    close.textContent = "X";
    div.appendChild(close);

    // добавляем поле в <div class="form-group"></div>
    div.appendChild(field);

    // Поле для ответа(здесь будут варианты выбора ответа и т.д.)
    let div2 = document.createElement("div");
    div.appendChild(div2);

    // добавляем <div class="form-group"><input ... /></div> в главный контейнер
    container.appendChild(div);

    // Если удачно всё выполнилось до этого и создался новый вопрос, инкрементируем
    questionId++;
}

function removeParent() {
    let revDiv = this.parentElement;
    revDiv.remove();
}

// Функция в зависимости от выбранного типа будет менять варианты ответа под вопросом
function changeComponents(questionType) {
    // Получаем элемент на котором произошло событие
    let questType = questionType.currentTarget;
    let selectedValue = questType.value;
    // здесь, зная id, мы получаем контейнер с вопросом(в дальнейшем я изменю этот костыль)
    let cont = document.getElementById("Questions[" + questType.id + "]");
    let nextDiv = cont.nextSibling;
    nextDiv.remove();
    let newDiv = document.createElement("div");

    if (selectedValue === "0") {
        newDiv.innerText = "Текст";

    } else if (selectedValue === "1") {
        newDiv.innerText = "Код";

    } else if (selectedValue === "2") {
        // здесь создаем кнопку, которая добавляет новый label с ratio кнопкой и вводом
        let addRadio = document.createElement("input");
        addRadio.setAttribute("value", "Добавить вариант ответа");
        addRadio.setAttribute("type", "button");
        addRadio.setAttribute("id", "addRadio[" + questType.id + "]");
        addRadio.addEventListener("click", function (e) {
            addNewRatio(e)
        });
        newDiv.appendChild(addRadio);

    } else if (selectedValue === "3") {
        let addCheckbox = document.createElement("input");
        addCheckbox.setAttribute("value", "Добавить вариант ответа");
        addCheckbox.setAttribute("type", "button");
        addCheckbox.setAttribute("id", "addСheckbox[" + questType.id + "]");
        addCheckbox.addEventListener("click", function (e) {
            addNewCheckbox(e)
        });
        newDiv.appendChild(addCheckbox);
    }
    cont.after(newDiv);
}

// функция по добавлению новых label с ratio и вводом
function addNewRatio(e) {
    // получаем из события нажатия, на каком объекте это произошло
    let addRad = e.currentTarget;

    let label = document.createElement("label");
    label.setAttribute("id", addRad.id);
    label.setAttribute("class", "ratio-label");

    let ratio = document.createElement("input");
    ratio.setAttribute("type", "radio");
    ratio.setAttribute("name", 'Ratio[' + addRad.id + ']')
    ratio.setAttribute("id", addRad.id);

    let ratioText = document.createElement("input");
    ratioText.setAttribute("placeholder", "Напишите вариант ответа");
    ratioText.setAttribute("type", "text");
    ratioText.setAttribute("id", addRad.id);

    label.appendChild(ratio);
    label.appendChild(ratioText);

    addRad.before(label);
}

// функция по добавлению новых label с checkbox и вводом
function addNewCheckbox(e) {
    let addCheck = e.currentTarget;

    let label = document.createElement("label");
    label.setAttribute("id", addCheck.id);
    label.setAttribute("class", "checkbox-label");

    let checkbox = document.createElement("input");
    checkbox.setAttribute("type", "checkbox");
    checkbox.setAttribute("name", 'Checkbox[' + addCheck.id + ']')
    checkbox.setAttribute("id", addCheck.id);

    let checkboxText = document.createElement("input");
    checkboxText.setAttribute("placeholder", "Напишите вариант ответа");
    checkboxText.setAttribute("type", "text");
    checkboxText.setAttribute("id", addCheck.id);

    label.appendChild(checkbox);
    label.appendChild(checkboxText);

    addCheck.before(label);
}