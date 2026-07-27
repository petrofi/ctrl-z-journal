# Ctrl+Z Günlüğü — Architecture

## Katmanlar

### CtrlZJournal.App

Kullanıcı arayüzü, WPF ekranları, ViewModel sınıfları ve navigasyon işlemleri.

### CtrlZJournal.Core

Domain modelleri, iş kuralları ve uygulamanın temel arayüzleri.

### CtrlZJournal.Infrastructure

SQLite, Entity Framework Core, dosya işlemleri ve veri erişimi.

### CtrlZJournal.Tests

Domain kuralları ve veri erişim işlemlerinin testleri.

## Bağımlılık Yönü

App → Core  
App → Infrastructure  
Infrastructure → Core  
Tests → Core  
Tests → Infrastructure