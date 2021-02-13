/********************************************************************************
** Form generated from reading UI file 'Task.ui'
**
** Created by: Qt User Interface Compiler version 6.0.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_TASK_H
#define UI_TASK_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QCheckBox>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Task
{
public:
    QPushButton *removeButton;
    QCheckBox *checkBox;
    QPushButton *editButton;

    void setupUi(QWidget *Task)
    {
        if (Task->objectName().isEmpty())
            Task->setObjectName(QString::fromUtf8("Task"));
        Task->resize(506, 326);
        removeButton = new QPushButton(Task);
        removeButton->setObjectName(QString::fromUtf8("removeButton"));
        removeButton->setGeometry(QRect(240, 110, 75, 23));
        checkBox = new QCheckBox(Task);
        checkBox->setObjectName(QString::fromUtf8("checkBox"));
        checkBox->setGeometry(QRect(50, 110, 70, 17));
        editButton = new QPushButton(Task);
        editButton->setObjectName(QString::fromUtf8("editButton"));
        editButton->setGeometry(QRect(160, 110, 75, 23));

        retranslateUi(Task);

        QMetaObject::connectSlotsByName(Task);
    } // setupUi

    void retranslateUi(QWidget *Task)
    {
        Task->setWindowTitle(QCoreApplication::translate("Task", "Form", nullptr));
        removeButton->setText(QCoreApplication::translate("Task", "Remove", nullptr));
        checkBox->setText(QCoreApplication::translate("Task", "CheckBox", nullptr));
        editButton->setText(QCoreApplication::translate("Task", "Edit", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Task: public Ui_Task {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_TASK_H
