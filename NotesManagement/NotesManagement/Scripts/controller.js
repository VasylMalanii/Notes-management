var app = angular.module('notesApp', []);
app.controller('notesController', function ($scope, $http) {

    $http.get(location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + "/api/notes")
    .then(function (response) {
        $scope.notes = response.data;
    });

    $scope.Note = {
        NoteId: 1,
        Title: '',
        Text: '',
        Category: ''
    };

    $scope.showEditFields = false;

    $scope.DeleteNote = function (index) {
        $http({
            method: 'DELETE',
            url: location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/api/notes/' + $scope.notes[index].NoteId,
        }).then(function successCallback(response) {
            $scope.notes.splice(index, 1);
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

    $scope.EditNote = function (currentNote) {
        $scope.showEditFields = true;
        $scope.Note = { NoteId: currentNote.NoteId, Title: currentNote.Title, Text: currentNote.Text, Category: currentNote.Category };
    };

    $scope.UpdateNote = function () {
        $scope.showEditFields = false;
        if ($scope.Note.Title != "" && $scope.Note.Text != "" && $scope.Note.Category != "") {
            $http({
                method: 'PUT',
                url: location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/api/notes/' + $scope.Note.NoteId,
                data: $scope.Note
            }).then(function successCallback(response) {
                $http.get(location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + "/api/notes")
                    .then(function (response) {
                        $scope.notes = response.data;
                    });
                $scope.ClearFields();
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Not all fields are filled!');
        }
    };

    $scope.Cancel = function () {
        $scope.ClearFields();
    };

    $scope.AddNote = function () {
        if ($scope.Note.Title != "" && $scope.Note.Text != "" && $scope.Note.Category != "") {
            $http({
                method: 'POST',
                url: location.protocol + '//' + location.hostname + (location.port ? ':' + location.port : '') + '/api/notes',
                data: $scope.Note
            }).then(function successCallback(response) {
                $scope.notes.push(response.data);
                $scope.ClearFields();
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Not all fields are filled!');
        }
    };

    $scope.ClearFields = function () {
        $scope.showEditFields = false;
        $scope.Note.Title = '';
        $scope.Note.Text = '';
        $scope.Note.Category = '';
    };
});