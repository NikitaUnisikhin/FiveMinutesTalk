// Проверка на совпадение паролей
function validatePassword() {
    let password = document.getElementById("reg-password");
    let confirm_password = document.getElementById("reg-password-confirm");

    if (password.value !== confirm_password.value) {
        confirm_password.setCustomValidity("Passwords Don't Match");
    } else {
        confirm_password.setCustomValidity('');
    }
}

/*const getNumber = (element) => {
    return Number(element.querySelector(".hat-question").querySelector(".number-question").querySelector(".number").textContent);
}*/

// У нас уже есть заранее склонированная форма, поэтому просто изменяем id в зависимости от questionId
export function newField(ev) {
    let baseForm = document.getElementById("Form1");
    const copied = baseForm.cloneNode(true);
    let questionId = document.getElementsByClassName("question-block").length;

    let addQue = ev.currentTarget;
    let parent = addQue.parentNode;
    questionId++;
    let newCopied = copied.cloneNode(true);
    newCopied.id = "Form" + questionId;

    let arrayIndex = questionId - 1;
    let formControl = newCopied.getElementsByClassName('name-question')[0];
    formControl.name = `questions[${arrayIndex}].Text`;
    let formSelect = newCopied.getElementsByClassName('form-select')[0];
    formSelect.name = `questions[${arrayIndex}].Type`;

    let select = newCopied.querySelector("select");
    select.id = String(questionId);
    select.addEventListener('change', function (questionType) {
        changeComponents(questionType)
    });
    newCopied.querySelector("#Question1").id = "Question" + questionId;
    newCopied.querySelector("#Answer1").id = "Answer" + questionId;
    newCopied.querySelector(".bottom-question").querySelector(".right-part").querySelector(".close-button").addEventListener('click', removeParent);

    let addQuestion = newCopied.querySelector("#AddQuestion1");
    addQuestion.id = "AddQuestion" + questionId;
    addQuestion.addEventListener('click', function (ev) {
        newField(ev)
    });

    let questions = Array.from(document.getElementsByClassName("question-block"));
    let number = Number(addQue.parentElement.querySelector(".hat-question")
        .querySelector(".number-question")
        .querySelector(".number").textContent);
    questions.splice(number, 0, newCopied);
    changeNumberQuestions(questions);
    setupSelector(newCopied.querySelector('.custom-select'));
    parent.after(newCopied);
}

// Обновляет номера вопросов
function changeNumberQuestions(questions) {
    for (let i = 0; i < questions.length; i++) {
        questions[i].querySelector(".hat-question").querySelector(".number-question").querySelector(".number").textContent = `${i + 1}`;
    }
}

// Удаляет родителя...
export function removeParent() {
    let revDiv = this.parentElement.parentElement.parentElement;
    let numberQuestion = Number(revDiv.parentElement.querySelector(".hat-question")
        .querySelector(".number-question")
        .querySelector(".number").textContent);
    if (numberQuestion === 1)
        return;

    changeNumberQuestions(Array.from(document.getElementsByClassName("question-block")));
    revDiv.remove();
}

// Функция в зависимости от выбранного типа будет менять варианты ответа под вопросом
export function changeComponents(questionType) {
    // Получаем элемент на котором произошло событие
    let questType = questionType.currentTarget;
    let selectedValue = questType.value;
    let id = questType.id;

    // Здесь, зная id, мы получаем контейнер с вопросом и удаляем его
    let cont = document.getElementById("Answer" + id);
    cont.remove();

    // Тут же создаём новый
    let newDiv = document.createElement("div");
    newDiv.setAttribute("id", "Answer" + id);
    if (selectedValue === "OpenQuestion") {
        let text = document.createElement("input");
        text.setAttribute("placeholder", "Ответ");
        text.setAttribute("class", "text-question");
        text.setAttribute("id", "Text" + id);
        newDiv.appendChild(text);

    } else if (selectedValue === "Code") {
        let textarea = document.createElement("textarea");
        textarea.setAttribute("id", "Textarea" + id);
        newDiv.appendChild(textarea);
        CodeMirror.fromTextArea(textarea, {
            lineNumbers: true,
            lineWrapping: true,
            matchBrackets: true,
            indentUnit: 5,
            lint: true
        });

    } else if (selectedValue === "MultipleAnswersQuestion") {
        // здесь создаем кнопку, которая добавляет новый label с checkbox кнопкой и вводом
        let addCheckbox = document.createElement("input");
        addCheckbox.setAttribute("value", "Добавить вариант ответа");
        addCheckbox.setAttribute("type", "button");
        addCheckbox.setAttribute("id", "AddСheckbox" + id);
        let col = 0;
        addCheckbox.addEventListener("click", function (e) {
            addNewCheckbox(e, id, col++)
        });

        addCheckbox.setAttribute("class", "add-checkbox");
        newDiv.appendChild(addCheckbox);
        addCheckbox.click();
    } else if (selectedValue === "Radio") {
        let addRadio = document.createElement("input");
        addRadio.setAttribute("value", "Добавить вариант ответа");
        addRadio.setAttribute("type", "button");
        addRadio.setAttribute("id", "AddRadio" + id);
        let col = 0;
        addRadio.addEventListener("click", function (e) {
            addNewRadio(e, id, col++)
        });
        addRadio.setAttribute("class", "add-radio");
        newDiv.appendChild(addRadio);
        addRadio.click();
    }
    let addQuest = document.getElementById("Question" + questType.id);
    addQuest.appendChild(newDiv);
}

// функция по добавлению новых label с checkbox и вводом
function addNewCheckbox(e, id, col) {
    let addCheck = e.currentTarget;

    let label = document.createElement("label");
    label.setAttribute("id", "Label" + id + `-${col}`);
    label.setAttribute("class", "checkbox-label");

    let checkbox = document.createElement("input");
    checkbox.setAttribute("type", "checkbox");
    checkbox.setAttribute("name", "Checkbox" + id)
    checkbox.setAttribute("id", "Checkbox" + id + `-${col}`);
    checkbox.onclick = () => {
        checkMark(checkbox.id, id - 1, col);
    };

    let inputContainer = document.createElement("div");
    inputContainer.setAttribute("class", "input-container");
    inputContainer.setAttribute("id", "inputContainer" + id + `-${col}`);

    let spanCheckbox = document.createElement("span");
    spanCheckbox.setAttribute("class", "checkbox-span");
    spanCheckbox.setAttribute("id", "SpanCheckbox" + id + `-${col}`);

    let checkboxText = document.createElement("input");
    checkboxText.setAttribute("placeholder", "Ответ");
    checkboxText.setAttribute("value", "Текст");
    checkboxText.setAttribute("type", "text");
    checkboxText.setAttribute("id", "CheckboxText" + id + `-${col}`);
    checkboxText.setAttribute("name", `questions[${id - 1}].AnswerOptions`);
    checkboxText.setAttribute("class", `checkbox-text`);
    checkboxText.setAttribute("onFocus", `this.select()`);

    inputContainer.appendChild(checkboxText);
    inputContainer.appendChild(spanCheckbox);

    label.appendChild(checkbox);
    label.appendChild(inputContainer);

    addCheck.before(label);
}

// функция по добавлению новых label с ratio и вводом
function addNewRadio(e, id, col) {
    // получаем из события нажатия, на каком объекте это произошло
    let addRad = e.currentTarget;

    let label = document.createElement("label");
    label.setAttribute("id", "Label" + id + `-${col}`);
    label.setAttribute("class", "radio-label");

    let radio = document.createElement("input");
    radio.setAttribute("type", "radio");
    radio.setAttribute("name", "Radio" + id)
    radio.setAttribute("id", "Radio" + id + `-${col}`);
    radio.onclick = () => {
        checkMark(radio.id, id - 1, col);
    };

    let inputContainer = document.createElement("div");
    inputContainer.setAttribute("class", "input-container");
    inputContainer.setAttribute("id", "inputContainerRadio" + id + `-${col}`);

    let spanRadio = document.createElement("span");
    spanRadio.setAttribute("class", "radio-span");
    spanRadio.setAttribute("id", "SpanRadio" + id + `-${col}`);

    let radioText = document.createElement("input");
    radioText.setAttribute("value", "Текст");
    radioText.setAttribute("placeholder", "Ответ");
    radioText.setAttribute("type", "text");
    radioText.setAttribute("name", `questions[${id - 1}].AnswerOptions`);
    radioText.setAttribute("id", "RadioText" + id + `-${col}`);
    radioText.setAttribute("class", `radio-text`);
    radioText.setAttribute("onFocus", `this.select()`);

    inputContainer.appendChild(radioText);
    inputContainer.appendChild(spanRadio);

    label.appendChild(radio);
    label.appendChild(inputContainer);

    addRad.before(label);
}

// обработка взаимодействия с чекбоксом
// let countCorrectAnswers = new Map();

function checkMark(checkboxId, questionIndex, answerIndex) {
    let checkbox = document.getElementById(checkboxId);
    if (checkbox.checked === true) {
        if (countCorrectAnswers[questionIndex] === undefined)
            countCorrectAnswers[questionIndex] = 0;
        countCorrectAnswers[questionIndex]++;
        checkbox.name = `questions[${questionIndex}].CorrectAnswers`
        checkbox.value = answerIndex;
    } else {
        countCorrectAnswers[questionIndex]--;
        checkbox.name = '';
    }
}

function openPopUp() {
    document.getElementById("overlay").style.display = "flex";
}

function closePopUp() {
    document.getElementById("overlay").style.display = "none";
}

function copyText() {
    let copyText = document.getElementById("quiz-id").textContent;
    navigator.clipboard.writeText(copyText);

    let sb = document.getElementById("snackbar");

    sb.className = "show";
    setTimeout(() => {
        sb.className = sb.className.replace("show", "");
    }, 2900);
}

//Делаем нормальный селектор
document.querySelectorAll('.custom-select').forEach(setupSelector);

function setupSelector(selector) {
    selector.addEventListener('mousedown', e => {
        if (window.innerWidth >= 420) {
            e.preventDefault();

            const select = selector.children[0];
            const dropDown = document.createElement('ul');
            dropDown.className = "selector-options";

            [...select.children].forEach(option => {
                const dropDownOption = document.createElement('li');
                dropDownOption.textContent = option.textContent;

                dropDownOption.addEventListener('mousedown', (e) => {
                    e.stopPropagation();
                    select.value = option.value;
                    selector.value = option.value;
                    select.dispatchEvent(new Event('change'));
                    selector.dispatchEvent(new Event('change'));
                    dropDown.remove();
                });

                dropDown.appendChild(dropDownOption);
            });

            selector.appendChild(dropDown);

            document.addEventListener('click', (e) => {
                if (!selector.contains(e.target)) {
                    dropDown.remove();
                }
            });
        }
    });
}

// Присваиваем всем календарям текущую дату и время
window.addEventListener('load', () => {
    let now = new Date();
    now.setMinutes(now.getMinutes() - now.getTimezoneOffset());

    now.setMilliseconds(null)
    now.setSeconds(null)

    let calendars = document.querySelectorAll('input[type=datetime-local]');

    for (let calendar of calendars)
        calendar.value = now.toISOString().slice(0, -1);
});
