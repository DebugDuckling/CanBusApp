#!/bin/bash

# Set project name
PROJECT_NAME="CanBusApp"

# Create project directories
mkdir -p $PROJECT_NAME
cd $PROJECT_NAME
mkdir -p src include resources

# Create .pro file
cat <<EOL > $PROJECT_NAME.pro
QT += core gui widgets

TARGET = $PROJECT_NAME
TEMPLATE = app

SOURCES += \\
    src/main.cpp \\
    src/main_window.cpp

HEADERS += \\
    include/main_window.h

RESOURCES +=

FORMS +=
EOL

# Create main.cpp
cat <<EOL > src/main.cpp
#include <QApplication>
#include "main_window.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();
    return a.exec();
}
EOL

# Create main_window.h
cat <<EOL > include/main_window.h
#ifndef MAIN_WINDOW_H
#define MAIN_WINDOW_H

#include <QMainWindow>
#include <QPushButton>
#include <QTextEdit>
#include <QComboBox>
#include <QCheckBox>
#include <QGroupBox>
#include <QVBoxLayout>
#include <QHBoxLayout>
#include <QLabel>
#include <QTimer>
#include <QJsonObject>

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private slots:
    void onConnectButtonClicked();
    void onUpdateButtonClicked();
    void updateUI();
    void getReconState();
    void buildTXMessage();

private:
    void createUi();
    void loadConfig();

    QPushButton *connectButton;
    QPushButton *updateButton;
    QTextEdit *txtNodeId;
    QTextEdit *txtRecons;
    QTextEdit *txtTxState;
    QTextEdit *txtTxFrames;
    QTextEdit *txtRxFrames;
    QCheckBox *chkContinuously;
    QCheckBox *chkAutoUpdate;

    QGroupBox *arcnetGroup;
    QGroupBox *optionsGroup;

    QVBoxLayout *mainLayout;

    QJsonObject config;

    QTimer *updateUITimer;
    QTimer *reconTimer;
    QTimer *txLanTimer;
};

#endif // MAIN_WINDOW_H
EOL

# Create main_window.cpp
cat <<EOL > src/main_window.cpp
#include "main_window.h"
#include <QJsonDocument>
#include <QJsonArray>
#include <QFile>
#include <QMessageBox>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
{
    createUi();
    loadConfig();

    // Initialize timers
    updateUITimer = new QTimer(this);
    reconTimer = new QTimer(this);
    txLanTimer = new QTimer(this);

    // Set timer intervals
    updateUITimer->setInterval(1000);
    reconTimer->setInterval(2000);
    txLanTimer->setInterval(3000);

    // Connect timers to slots
    connect(updateUITimer, &QTimer::timeout, this, &MainWindow::updateUI);
    connect(reconTimer, &QTimer::timeout, this, &MainWindow::getReconState);
    connect(txLanTimer, &QTimer::timeout, this, &MainWindow::buildTXMessage);

    // Start timers
    updateUITimer->start();
    reconTimer->start();
    txLanTimer->start();
}

MainWindow::~MainWindow() {}

void MainWindow::createUi()
{
    arcnetGroup = new QGroupBox("ARCNET", this);
    optionsGroup = new QGroupBox("Options", this);

    txtNodeId = new QTextEdit(this);
    txtRecons = new QTextEdit(this);
    txtTxState = new QTextEdit(this);
    txtTxFrames = new QTextEdit(this);
    txtRxFrames = new QTextEdit(this);
    chkContinuously = new QCheckBox("Tx Continuous", this);
    chkAutoUpdate = new QCheckBox("Auto Update", this);
    connectButton = new QPushButton("Connect", this);
    updateButton = new QPushButton("Update", this);

    connect(connectButton, &QPushButton::clicked, this, &MainWindow::onConnectButtonClicked);
    connect(updateButton, &QPushButton::clicked, this, &MainWindow::onUpdateButtonClicked);

    QVBoxLayout *arcnetLayout = new QVBoxLayout;
    arcnetLayout->addWidget(new QLabel("Node ID"));
    arcnetLayout->addWidget(txtNodeId);
    arcnetLayout->addWidget(new QLabel("Recons"));
    arcnetLayout->addWidget(txtRecons);
    arcnetLayout->addWidget(new QLabel("Tx State"));
    arcnetLayout->addWidget(txtTxState);
    arcnetLayout->addWidget(new QLabel("Tx Frames"));
    arcnetLayout->addWidget(txtTxFrames);
    arcnetLayout->addWidget(new QLabel("Rx Frames"));
    arcnetLayout->addWidget(txtRxFrames);
    arcnetLayout->addWidget(connectButton);
    arcnetGroup->setLayout(arcnetLayout);

    QVBoxLayout *optionsLayout = new QVBoxLayout;
    optionsLayout->addWidget(chkContinuously);
    optionsLayout->addWidget(chkAutoUpdate);
    optionsLayout->addWidget(updateButton);
    optionsGroup->setLayout(optionsLayout);

    QHBoxLayout *mainHLayout = new QHBoxLayout;
    mainHLayout->addWidget(arcnetGroup);
    mainHLayout->addWidget(optionsGroup);

    QWidget *centralWidget = new QWidget(this);
    centralWidget->setLayout(mainHLayout);

    setCentralWidget(centralWidget);
}

void MainWindow::loadConfig()
{
    QFile file("commands_config.json");
    if (!file.open(QIODevice::ReadOnly | QIODevice::Text))
    {
        QMessageBox::critical(this, "Error", "Could not open config file.");
        return;
    }

    QByteArray data = file.readAll();
    QJsonDocument doc(QJsonDocument::fromJson(data));
    config = doc.object();

    // Load dynamic controls from config here
}

void MainWindow::onConnectButtonClicked()
{
    QApplication::setOverrideCursor(Qt::WaitCursor);

    // Collect data from UI
    QString nodeId = txtNodeId->toPlainText();
    int recons = txtRecons->toPlainText().toInt();
    QString txState = txtTxState->toPlainText();
    int txFrames = txtTxFrames->toPlainText().toInt();
    int rxFrames = txtRxFrames->toPlainText().toInt();
    bool txContinuous = chkContinuously->isChecked();
    bool autoUpdate = chkAutoUpdate->isChecked();

    // Perform connection logic

    QApplication::restoreOverrideCursor();
}

void MainWindow::onUpdateButtonClicked()
{
    // Implement the update logic here
}

void MainWindow::updateUI()
{
    // Implement the logic to update the UI
}

void MainWindow::getReconState()
{
    // Implement the logic to get the recon state
}

void MainWindow::buildTXMessage()
{
    // Implement the logic to build the TX message
}
EOL

# Create commands_config.json
cat <<EOL > commands_config.json
{
  "commands": [
    {
      "label": "Command 1",
      "type": "combobox",
      "options": ["enum 1", "enum 2", "enum 3", "enum 4"],
      "defaultValue": "enum 2",
      "code": ""
    },
    {
      "label": "Command 2",
      "type": "checkbox",
      "defaultValue": "true",
      "code": ""
    },
    {
      "label": "Command 3",
      "type": "textbox",
      "defaultValue": "default text",
      "code": ""
    },
    {
      "label": "Command 4",
      "type": "button",
      "buttonText": "Click Me",
      "code": ""
    }
  ],
  "status": [
    {
      "label": "Status 1",
      "type": "textbox",
      "defaultValue": "Initial Status 1",
      "code": ""
    },
    {
      "label": "Status 2",
      "type": "checkbox",
      "defaultValue": "false",
      "code": ""
    }
  ]
}
EOL

echo "Qt project structure created successfully!"
