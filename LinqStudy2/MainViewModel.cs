﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqStudy2.Data;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections;

namespace LinqStudy2
{
    class MainViewModel : ViewModelBase
    {
        #region 秘密
        public MainViewModel()
        {
            GetAllStudentsCommand = new RelayCommand(() => AllStudents = DataSource.GetAll生徒());
            学年総合順位Command = new RelayCommand(Create学年総合順位);
            クラス別順位Command = new RelayCommand(Createクラス別順位);
            科目別順位Command = new RelayCommand(Create科目別順位);
            教科分析Command = new RelayCommand(Create科目分析);
            検索Command = new RelayCommand(検索);

            科目一覧 = new[] { "" }.Concat(DataSource.GetAll科目().Select(a => a.試験名)).ToList();
            クラス一覧 = new List<string> { "", "A", "B", "C", "D", "E", "F" };
            男女一覧 = new List<string> { "", "男", "女" };

        }

        public List<string> 科目一覧 { get; private set; }
        public List<string> クラス一覧 { get; private set; }
        public List<string> 男女一覧 { get; private set; }
        public string 選択科目 { get; set; }
        public string 選択クラス { get; set; }
        public string 選択男女 { get; set; }
        public string 検索文字列 { get; set; }

        private IList _検索結果;

        public IList 検索結果
        {
            get { return _検索結果; }
            set
            {
                Set(() => 検索結果, ref _検索結果, value);
            }
        }



        private IList allStudents;

        public IList AllStudents
        {
            get { return allStudents; }
            set
            {
                Set(() => AllStudents, ref allStudents, value);
            }
        }

        private IList _学年総合順位;

        public IList 学年総合順位
        {
            get { return _学年総合順位; }
            set
            {
                Set(() => 学年総合順位, ref _学年総合順位, value);
            }
        }

        private IList _クラス別順位;

        public IList クラス別順位
        {
            get { return _クラス別順位; }
            set
            {
                Set(() => クラス別順位, ref _クラス別順位, value);
            }
        }

        private IList _科目別順位;

        public IList 科目別順位
        {
            get { return _科目別順位; }
            set
            {
                Set(() => 科目別順位, ref _科目別順位, value);
            }
        }

        private IList _教科分析;

        public IList 教科分析
        {
            get { return _教科分析; }
            set
            {
                Set(() => 教科分析, ref _教科分析, value);
            }
        }

        public ICommand GetAllStudentsCommand { get; private set; }

        public ICommand 学年総合順位Command { get; private set; }

        public ICommand クラス別順位Command { get; private set; }

        public ICommand 科目別順位Command { get; private set; }

        public ICommand 教科分析Command { get; private set; }

        public ICommand 検索Command { get; private set; }
        #endregion
        
        public void Create学年総合順位()
        {
            学年総合順位 = DataSource.GetAll生徒().Select(s => new { 生徒情報 = s, 合計点 = s.成績.Sum(a => a.得点) })
                    .OrderByDescending(a => a.合計点)
                    .Select((a, i) =>
                        new
                        {
                            順位 = i + 1,
                            クラス = a.生徒情報.クラス,
                            氏名 = a.生徒情報.姓 + " " + a.生徒情報.名,
                            合計点 = a.合計点
                        })
                    .Take(100)
                    .ToList();
        }

        public void Createクラス別順位()
        {
            クラス別順位 = DataSource.GetAll生徒().Select(s => new { 生徒情報 = s, 合計点 = s.成績.Sum(a => a.得点) })
            .GroupBy(s => s.生徒情報.クラス)
            .Select(g => new
            {
                クラス名 = g.Key,
                順位 = g.OrderByDescending(a => a.合計点)
                        .Select((a, i) =>
                            new
                            {
                                順位 = i + 1,
                                氏名 = a.生徒情報.姓 + " " + a.生徒情報.名,
                                合計点 = a.合計点
                            }).ToList()
            }).ToList();
        }

        public void Create科目別順位()
        {
            科目別順位 = DataSource.GetAll生徒().SelectMany(s => s.成績, (a, b) => new { a, b })
                                    .GroupBy(a => a.b.試験名)
                                    .Select(g => new
                                    {
                                        試験名 = g.Key,
                                        順位 = g.OrderByDescending(a => a.b.得点)
                                                .Select((a, i) => new
                                                {
                                                    順位 = i + 1,
                                                    クラス名 = a.a.クラス,
                                                    氏名 = a.a.姓 + " " + a.a.名,
                                                    得点 = a.b.得点
                                                }).Take(100).ToList()
                                    }).ToList();
        }

        public void Create科目分析()
        {
            教科分析 = DataSource.GetAll科目().GroupJoin(
                            DataSource.GetAll生徒().SelectMany(s => s.成績),
                            a => a.試験名, b => b.試験名, (a, b) => new { a, b })
                        .Select(g => new { g.a.教科名, g.a.試験名, g.a.満点, Source = g.b.Select(s => s.得点).ToList() })
                        .Select(g => new
                        {
                            教科名 = g.教科名,
                            試験名 = g.試験名,
                            満点 = g.満点,
                            受験者数 = g.Source.Count,
                            最高点 = g.Source.Max(),
                            最低点 = g.Source.Min(),
                            平均点 = g.Source.Average(),
                        }).ToList();
        }

        public void 検索()
        {
            var source = DataSource.GetAll生徒().SelectMany(s => s.成績, (a, b) => new { a, b });

            if (!string.IsNullOrEmpty(this.選択クラス))
            {
                source = source.Where(a => a.a.クラス == this.選択クラス);
            }

            if (!string.IsNullOrEmpty(this.選択科目))
            {
                source = source.Where(a => a.b.試験名 == this.選択科目);
            }

            if (!string.IsNullOrEmpty(this.選択男女))
            {
                source = source.Where(a => a.a.性別 == this.選択男女);
            }

            if (!string.IsNullOrEmpty(this.検索文字列))
            {
                source = source.Where(a => (a.a.姓 + a.a.名).Contains(this.検索文字列) || (a.a.セイ + a.a.メイ).Contains(this.検索文字列));
            }

            検索結果 = source.Select(a => new
            {
                クラス = a.a.クラス,
                名前 = a.a.姓 + " " + a.a.名,
                フリガナ = a.a.セイ + "  " + a.a.メイ,
                性別 = a.a.性別,
                科目 = a.b.試験名,
                得点 = a.b.得点
            }).ToList();
        }
    }
}
