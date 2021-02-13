/********************************************************************************
** Form generated from reading UI file 'ToDo.ui'
**
** Created by: Qt User Interface Compiler version 6.0.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_TODO_H
#define UI_TODO_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QLabel>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_ToDo
{
public:
    QWidget *centralwidget;
    QWidget *horizontalLayoutWidget;
    QHBoxLayout *toolbarLayout;
    QLabel *statusLabel;
    QSpacerItem *horizontalSpacer;
    QPushButton *addTaskButton;
    QWidget *verticalLayoutWidget;
    QVBoxLayout *tasksLayout;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *ToDo)
    {
        if (ToDo->objectName().isEmpty())
            ToDo->setObjectName(QString::fromUtf8("ToDo"));
        ToDo->resize(361, 222);
        centralwidget = new QWidget(ToDo);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        horizontalLayoutWidget = new QWidget(centralwidget);
        horizontalLayoutWidget->setObjectName(QString::fromUtf8("horizontalLayoutWidget"));
        horizontalLayoutWidget->setGeometry(QRect(0, 0, 361, 31));
        toolbarLayout = new QHBoxLayout(horizontalLayoutWidget);
        toolbarLayout->setObjectName(QString::fromUtf8("toolbarLayout"));
        toolbarLayout->setContentsMargins(0, 0, 0, 0);
        statusLabel = new QLabel(horizontalLayoutWidget);
        statusLabel->setObjectName(QString::fromUtf8("statusLabel"));

        toolbarLayout->addWidget(statusLabel);

        horizontalSpacer = new QSpacerItem(148, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        toolbarLayout->addItem(horizontalSpacer);

        addTaskButton = new QPushButton(horizontalLayoutWidget);
        addTaskButton->setObjectName(QString::fromUtf8("addTaskButton"));

        toolbarLayout->addWidget(addTaskButton);

        verticalLayoutWidget = new QWidget(centralwidget);
        verticalLayoutWidget->setObjectName(QString::fromUtf8("verticalLayoutWidget"));
        verticalLayoutWidget->setGeometry(QRect(-1, -1, 371, 181));
        tasksLayout = new QVBoxLayout(verticalLayoutWidget);
        tasksLayout->setObjectName(QString::fromUtf8("tasksLayout"));
        tasksLayout->setContentsMargins(0, 0, 0, 0);
        ToDo->setCentralWidget(centralwidget);
        menubar = new QMenuBar(ToDo);
        menubar->setObjectName(QString::fromUtf8("menubar"));
        menubar->setGeometry(QRect(0, 0, 361, 21));
        ToDo->setMenuBar(menubar);
        statusbar = new QStatusBar(ToDo);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        ToDo->setStatusBar(statusbar);

        retranslateUi(ToDo);

        QMetaObject::connectSlotsByName(ToDo);
    } // setupUi

    void retranslateUi(QMainWindow *ToDo)
    {
        ToDo->setWindowTitle(QCoreApplication::translate("ToDo", "ToDo", nullptr));
        statusLabel->setText(QCoreApplication::translate("ToDo", "Status: 0 todo / 0 done", nullptr));
        addTaskButton->setText(QCoreApplication::translate("ToDo", "Add task", nullptr));
    } // retranslateUi

};

namespace Ui {
    class ToDo: public Ui_ToDo {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_TODO_H
