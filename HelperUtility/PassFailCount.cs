// *************************************************************
// Coder Camps
// 8444 N. 90th Street St. 110
// Scottsdale, AZ
// -- SBS ~ 20180531
// Copyright (c) 2016-18
// Project: Utility and Tools
// *************************************************************

namespace Utility
{
  using System;

  /// <summary>
  /// Oject to keep track of passed and failed tests
  /// </summary>
  public class PassFailCount
  {
    /// <summary>
    /// Gets or sets the pass count of tests
    /// </summary>
    /// <value>
    /// PassCount
    /// </value>
    public int PassCount { get; set; }

    /// <summary>
    /// Gets or sets the failed test count.
    /// </summary>
    /// <value>
    /// Failcount
    /// </value>
    public int FailCount { get; set; }

  }
}
